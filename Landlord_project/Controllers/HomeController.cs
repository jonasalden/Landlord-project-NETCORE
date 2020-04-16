using Landlord_project.Data;
using Landlord_project.Models;
using Landlord_project.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Landlord_project.Controllers
{
    public class HomeController : Controller
    {
        #region Fields
        private IWebHostEnvironment _environment;
        private readonly string folderPath = "\\images\\";
        private IGenericRepository<Residence> _residenceRepository;
        #endregion

        #region Constructor
        public HomeController(IWebHostEnvironment environment, IGenericRepository<Residence> residenceRepository)
        {
            _environment = environment;
            _residenceRepository = residenceRepository;
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
            var residences = _residenceRepository.GetAll(x => x.ResidenceReports).ToList();
            var model = new RentalModel();

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

        [Route("hyresledigt/detaljer/{id}")]
        public IActionResult RentalDetails(int id)
        {
            var residence = _residenceRepository.GetById(id);
            if (residence == null)
                return View(null);

            var model = new ResidenceDetailModel
            {
                Id = residence.Id,
                Address = residence.Address,
                DateBuilt = residence.DateBuilt,
                DateRenovated = residence.DateRenovated,
                Area = residence.Area,
                FloorNumber = residence.FloorNumber,
                HousingNumber = residence.HousingNumber,
                Latitude = residence.Latitude,
                Longitude = residence.Longitude,
                Rooms = residence.Rooms,
                Size = residence.Size,
                RentalPrice = residence.RentalPrice,
                ZipCode = residence.ZipCode
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult FilterPrice(int price, int rooms)
        {
            var residences = _residenceRepository.GetAll();

            if (price >= 0)
                residences = residences.Where(re => re.RentalPrice >= price);

            if (rooms >= 1)
                residences = residences.Where(re => re.Rooms >= rooms);
            //var query = (IQueryable<Residence>)_context.Residences;

            //if (price >= 0)
            //    query = query.Where(re => re.RentalPrice >= price);
            //if (rooms >= 1)
            //{
            //    query = query.Where(re => re.Rooms >= rooms);
            //}

            //var residences = query.ToList();

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
            var address = _residenceRepository.GetById(residenceId).Address;
            var model = new ResidenceApplication
            {
                ResidenceId = residenceId,
                ResidenceName = address
            };
            return PartialView("_GenericModal", model);
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

            var webRootpath = _environment.WebRootPath;
            var fullPath = webRootpath + folderPath + residence.ImageName;

            if (System.IO.File.Exists(fullPath))
            {
                var fileOnDisk = new FileStream(fullPath, FileMode.Open);
                byte[] fileBytes;
                using (var br = new BinaryReader(fileOnDisk))
                {
                    fileBytes = br.ReadBytes((int)fileOnDisk.Length);
                }
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
