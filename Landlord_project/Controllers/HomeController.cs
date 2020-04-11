using Landlord_project.Data;
using Landlord_project.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Landlord_project.Controllers
{
    public class HomeController : Controller
    {
        #region Fields
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;
        private IWebHostEnvironment _environment;
        private readonly string folderPath = "\\images\\";
        #endregion

        #region Constructor
        public HomeController(ILogger<HomeController> logger, DataContext context, IWebHostEnvironment environment)
        {
            _logger = logger;
            _context = context;
            _environment = environment;
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
            var residences = _context.Residences.ToList();
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
                        RentalPrice = res.RentalPrice
                    };
                    model.Add(residence);
                }
            }
            return View(model);
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
            var residence = _context.Residences.FirstOrDefault(r => r.Id == id);

            if (residence == null)
                return NotFound();

            string webRootpath = _environment.WebRootPath;
            string fullPath = webRootpath + folderPath + residence.ImageName;

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
