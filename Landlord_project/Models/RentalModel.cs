using Landlord_project.Models.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Landlord_project.Models
{
    public class RentalModel
    {
        public List<ResidenceModel> Residence { get; set; }
        public List<SelectListItem> Areas { get; set; }
        [Display(Name = "Område")]
        public string SelectedArea { get; set; }
        public int NumResidences { get; set; }
        public decimal MinRent { get; set; }
        public decimal MaxRent { get; set; }
        public int MaxRooms { get; set; }
        [Display(Name = "Sortera efter")]
        public SortByModel SortBy { get; set; }
        public RentalModel()
        {
            Residence = new List<ResidenceModel>();
        }
    }
}
