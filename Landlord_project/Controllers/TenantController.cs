using Landlord_project.DAL.Repositories;
using Landlord_project.Models;
using Landlord_project.Services.Interfaces;
using Landlord_project.Shared.Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Landlord_project.Controllers
{
    public class TenantController : Controller
    {
        #region Fields
        private readonly IWebHostEnvironment _environment;
        private readonly IGenericRepository<Residence> _residenceRepository;
        private readonly IGenericRepository<ResidenceReport> _residenceReportRepository;
        private readonly IGenericRepository<FaqQuestion> _faqQuestionRepository;
        private readonly IPictureService _pictureService;
        #endregion

        #region Constructor
        public TenantController(IGenericRepository<FaqQuestion> faqQuestionRepository, IPictureService pictureService, IWebHostEnvironment environment, IGenericRepository<Residence> residenceRepository, IGenericRepository<ResidenceReport> residenceReportRepository)
        {
            _environment = environment;
            _residenceRepository = residenceRepository;
            _residenceReportRepository = residenceReportRepository;
            _pictureService = pictureService;
            _faqQuestionRepository = faqQuestionRepository;
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

                if (bytes != null && bytes.Keys.Any() && bytes.Values.Any())
                {
                    model.ImageFile = bytes.Keys.First();
                    model.ImageName = bytes.Values.First();
                }
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

            TempData["ReportMessage"] = $"Tack! <strong>{reportModel.FirstName}</strong>, Vi återkommer till dig inom kort. (bild sparad i {_environment.WebRootPath}images\\reports\\)";

            return RedirectToAction("Index", "Home");
        }

        [Route("faq")]
        public IActionResult Faq()
        {
           var test = _faqQuestionRepository.Get(x => x.Category).ToList();
            return View();
        }
        #endregion
    }
}