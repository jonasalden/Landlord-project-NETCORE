using Landlord_project.Data;
using Landlord_project.Models;
using Landlord_project.Repositories;
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
        #endregion

        #region Constructor
        public TenantController(IWebHostEnvironment environment, IGenericRepository<Residence> residenceRepository, IGenericRepository<ResidenceReport> residenceReportRepository)
        {
            _environment = environment;
            _residenceRepository = residenceRepository;
            _residenceReportRepository = residenceReportRepository;
        }
        #endregion

        #region Methods
        [HttpGet]
        [Route("felanmalan")]
        public IActionResult Report()
        {
            var model = new ReportModel();

            var residences = _residenceRepository.GetAll();

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

            var imageDbName = string.Empty;

            if (model.Image != null && model.Image.Length > 0)
            {
                model.ImageMimeType = model.Image.ContentType;
                model.ImageName = Path.GetFileName(model.Image.FileName);
                var imageCleanName = Path.GetFileNameWithoutExtension(model.Image.FileName);
                using (var memoryStream = new MemoryStream())
                {
                    model.Image.CopyTo(memoryStream);
                    model.ImageFile = memoryStream.ToArray();
                }

                model.DateCreated = DateTime.Now;
                var imagePath = @"images\reports\";
                var imageExtension = Path.GetExtension(model.Image.FileName);
                imageDbName = $"report_{imageCleanName}" + imageExtension;
                var relativeImagePath = imagePath + imageDbName;
                var absImagePath = Path.Combine(_environment.WebRootPath, relativeImagePath);

                using (var fileStream = new FileStream(absImagePath, FileMode.Create))
                {
                    model.Image.CopyTo(fileStream);
                }
            }

            var reportModel = new ResidenceReport
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Description = model.Description,
                Email = model.Email,
                ImageFile = model.ImageFile ?? null,
                ImageMimeType = model.ImageMimeType ?? null,
                ImageName = imageDbName ?? null,
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