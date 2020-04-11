using Landlord_project.Data;
using Landlord_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Landlord_project.Controllers
{
    public class HomeController : Controller
    {
        #region Fields
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;
        #endregion

        #region Constructor
        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
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
                        Address = res.Address,
                        Area = res.Area,
                        AvailableFrom = res.ShowFrom.ToString("dd/MM/yyyy"),
                        Image = res.Image,
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
    }
}
