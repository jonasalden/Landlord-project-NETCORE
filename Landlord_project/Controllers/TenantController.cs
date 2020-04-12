using Landlord_project.Data;
using Landlord_project.Models;
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
        private readonly DataContext _context;
        #endregion

        #region Constructor
        public TenantController(DataContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        [HttpGet]
        [Route("felanmalan")]
        public IActionResult Report()
        {
            var model = new ReportModel();

            var residences = _context.Residences.ToList();

            if (residences.Any())
            {
                model.Residences = new List<SelectListItem>();
                foreach (var res in residences)
                {
                    model.Residences.Add(new SelectListItem {Text = res.Address, Value = res.Id.ToString()});
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

            if (model.Image != null && model.Image.Length > 0)
            {
                model.ImageMimeType = model.Image.ContentType;
                model.ImageName = Path.GetFileName(model.Image.FileName);

                using (var memoryStream = new MemoryStream())
                {
                    model.Image.CopyTo(memoryStream);
                    model.ImageFile = memoryStream.ToArray();
                }

                var reportModel = new ResidenceReport
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Description = model.Description,
                    Email = model.Email,
                    ImageFile = model.ImageFile,
                    ImageMimeType = model.ImageMimeType,
                    ImageName = model.ImageName,
                    Phone = model.Phone,
                    DateCreated = DateTime.Now,
                    ResidenceId = model.ResidenceId
                };
                _context.ResidenceReports.Add(reportModel);
                _context.SaveChanges();
                return View(nameof(Index));
            }

            return null;
        }
        #endregion
    }
}