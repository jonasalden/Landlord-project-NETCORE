using Landlord_project.Data;
using Landlord_project.Models;
using Landlord_project.Models.Enums;
using Landlord_project.Repositories;
using Landlord_project.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Landlord_project.Controllers
{
    public class HomeController : Controller
    {
        #region Fields
        private readonly IWebHostEnvironment _environment;
        private readonly IGenericRepository<Residence> _residenceRepository;
        private readonly IPictureService _pictureService;
        #endregion

        #region Constructor
        public HomeController(IWebHostEnvironment environment, IGenericRepository<Residence> residenceRepository, IPictureService pictureService)
        {
            _environment = environment;
            _residenceRepository = residenceRepository;
            _pictureService = pictureService;
        }
        #endregion

        #region Methods
        public IActionResult Index()
        {
            return View();
        }
        [Route("hyresledigt")]
        public IActionResult Rental()
        {

            var residences = _residenceRepository.Get(x => x.ResidenceReports).ToList().OrderBy(pr => pr.ApplicationFrom);
            var cities = residences.Select(r => r.Area).Distinct();
            var model = new RentalModel
            {
                Areas = new List<SelectListItem>()
            };
            if (cities.Any())
            {
                foreach (var area in cities)
                {
                    model.Areas.Add(new SelectListItem { Text = area, Value = area });
                }
            }

            if (residences.Any())
            {
                foreach (var res in residences)
                {
                    var residence = new ResidenceModel
                    {
                        Id = res.Id,
                        Address = res.Address,
                        Area = res.Area,
                        AvailableFrom = res.ShowFrom.ToString("dd/MM/yyyy"),
                        Image = res.ImageName,
                        Rooms = res.Rooms,
                        Size = res.Size,
                        RentalPrice = decimal.Round(res.RentalPrice),
                    };
                    model.Residence.Add(residence);
                }
                model.NumResidences = model.Residence.Count();

                var rentalPrices = model.Residence.Select(re => re.RentalPrice).OrderBy(prices => prices);
                if (rentalPrices.Any())
                {
                    model.MinRent = rentalPrices.FirstOrDefault();
                    model.MaxRent = rentalPrices.OrderByDescending(prices => prices).FirstOrDefault();
                }

                var rentalRooms = model.Residence.Select(r => r.Rooms).OrderByDescending(room => room);
                if (rentalRooms.Any())
                {
                    model.MaxRooms = rentalRooms.FirstOrDefault();
                }
            }
            return View(model);
        }

        [Route("hyresledigt/detaljer/{id}/{ActivateRegisterForm?}")]
        public IActionResult RentalDetails(int id, bool ActivateRegisterForm)
        {
            var residence = _residenceRepository.GetById(id);
            if (residence == null)
                return View(null);

            var model = new ResidenceDetailModel
            {
                Id = residence.Id,
                Address = residence.Address,
                DateBuilt = residence.DateBuilt.Year,
                DateRenovated = residence.DateRenovated.Year,
                Area = residence.Area,
                FloorNumber = residence.FloorNumber,
                HousingNumber = residence.HousingNumber,
                Latitude = residence.Latitude,
                Longitude = residence.Longitude,
                Rooms = residence.Rooms,
                Size = residence.Size,
                RentalPrice = decimal.Round(residence.RentalPrice),
                ZipCode = residence.ZipCode,
                ActivateRegisterForm = ActivateRegisterForm
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Filter(int minPrice, int maxPrice, int rooms, string area, int sortBy)
        {
            var residences = _residenceRepository.Get();

            if (minPrice >= 0)
                residences = residences.Where(re => re.RentalPrice >= minPrice);

            if (maxPrice >= 0)
                residences = residences.Where(re => re.RentalPrice <= maxPrice);

            if (rooms >= 1)
                residences = residences.Where(re => re.Rooms >= rooms);

            if (!string.IsNullOrWhiteSpace(area))
                residences = residences.Where(re => re.Area == area);

            if (sortBy > 0 && residences.Count() > 1)
            {
                switch (sortBy)
                {
                    case (int)SortByModel.Availability:
                        residences = residences.OrderBy(re => re.ApplicationFrom);
                        break;
                    case (int)SortByModel.RentFrom:
                        residences = residences.OrderBy(re => re.RentalPrice);
                        break;
                    case (int)SortByModel.RentTo:
                        residences = residences.OrderByDescending(re => re.RentalPrice);
                        break;
                    case (int)SortByModel.Size:
                        residences = residences.OrderByDescending(re => re.Size);
                        break;
                    case (int)SortByModel.Rooms:
                        residences = residences.OrderByDescending(re => re.Rooms);
                        break;
                }
            }

            var model = new List<ResidenceModel>();
            if (residences.Any())
            {
                foreach (var res in residences)
                {
                    var residence = new ResidenceModel
                    {
                        Id = res.Id,
                        Address = res.Address,
                        Area = res.Area,
                        AvailableFrom = res.ShowFrom.ToString("dd/MM/yyyy"),
                        Image = res.ImageName,
                        Rooms = res.Rooms,
                        Size = res.Size,
                        RentalPrice = res.RentalPrice,
                    };
                    model.Add(residence);
                }
            }
            return PartialView("_ResidenceThumb", model);
        }

        [HttpGet]
        public IActionResult RentalApplication(int residenceId)
        {
            var residence = _residenceRepository.GetById(residenceId);
            var address = string.Empty;

            if (residence != null && !string.IsNullOrWhiteSpace(residence.Address))
                address = residence.Address;

            var model = new ResidenceApplication
            {
                ResidenceId = residenceId,
                ResidenceName = address
            };
            return PartialView("_GenericModal", model);
        }

        [HttpPost]
        public IActionResult RentalApplication(ResidenceApplication model)
        {
            if (!ModelState.IsValid)
            {
                var test = "";
            }
            return null;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion

        #region Helpers
        public IActionResult GetResidenceImage(int id)
        {
            var residence = _residenceRepository.GetById(id);
            if (residence == null)
                return NotFound();

            var fileBytes = _pictureService.GetPictureBytesByPath(_environment.WebRootPath, @"\images\", residence.ImageName);

            if (fileBytes.Any())
            {
                return File(fileBytes, residence.ImageMimeType);
            }
            else
            {
                if (residence.ImageFile == null)
                    return NotFound();

                return File(residence.ImageFile, residence.ImageMimeType);
            }
        }
        #endregion
    }
}
