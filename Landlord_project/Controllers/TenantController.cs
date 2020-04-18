using Landlord_project.Data;
using Landlord_project.Models;
using Landlord_project.Repositories;
using Landlord_project.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Landlord_project.Controllers
{
    public class TenantController : Controller
    {
        #region Fields
        private readonly IWebHostEnvironment _environment;
        private IGenericRepository<Residence> _residenceRepository;
        private IGenericRepository<ResidenceReport> _residenceReportRepository;
        private readonly string imagePath = @"images\reports\";
        private readonly IPictureService _pictureService;
        #endregion

        #region Constructor
        public TenantController(IPictureService pictureService, IWebHostEnvironment environment, IGenericRepository<Residence> residenceRepository, IGenericRepository<ResidenceReport> residenceReportRepository)
        {
            _environment = environment;
            _residenceRepository = residenceRepository;
            _residenceReportRepository = residenceReportRepository;
            _pictureService = pictureService;
        }
        #endregion

        #region Methods
        [HttpGet]
        [Route("felanmalan")]
        public IActionResult Report()
        {
            var model = new ReportModel();

            var residences = _residenceRepository.Get();

            if (residences.Any())
            {
                model.Residences = new List<SelectListItem>();
                foreach (var res in residences)
                {
                    model.Residences.Add(new SelectListItem { Text = res.Address, Value = res.Id.ToString() });
                }
            }

            return View(model);
        }
        [HttpPost]
        [Route("felanmalan/{model?}")]
        public IActionResult Report(ReportModel model)
        {
            if (!ModelState.IsValid)
                return NotFound();

            model.DateCreated = DateTime.Now;
            if (model.Image != null && model.Image.Length > 0)
            {
                var bytes = _pictureService.UploadPicture(_environment, model.Image, $"fel_{model.Email}_{model.DateCreated.ToString("yyyyMMddHHmmss")}");
                model.ImageFile = bytes.Keys.First();
                model.ImageName = bytes.Values.First();
            }

            var reportModel = new ResidenceReport
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Description = model.Description,
                Email = model.Email,
                ImageFile = model.ImageFile ?? null,
                ImageMimeType = model.Image.ContentType,
                ImageName = model.ImageName,
                Phone = model.Phone,
                ResidenceId = model.ResidenceId,
                DateCreated = model.DateCreated,
                CanAccessResidence = model.CanAccessResidence,
                HousingNumber = model.HousingNumber
            };
            _residenceReportRepository.Insert(reportModel);
            return RedirectToAction("Index", "Home");
        }

        [Route("faq")]
        public IActionResult Faq()
        {
            return View();
        }
        #endregion
    }
}