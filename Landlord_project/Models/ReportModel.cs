using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Landlord_project.Models
{
    public class ReportModel
    {
        [Display(Name = "Förnamn *")]
        public string FirstName { get; set; }
        [Display(Name = "Efternamn *")]
        public string LastName { get; set; }
        [Display(Name = "Telefonnummer *")]
        public string Phone { get; set; }
        [Display(Name = "Epostadress *")]
        public string Email { get; set; }
        [Display(Name = "Beskrivning av problem *")]
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        [Display(Name = "Bifoga bild")]
        public IFormFile Image { get; set; }
        public string ImageName { get; set; }
        public byte[] ImageFile { get; set; }
        public string ImageMimeType { get; set; }
        [Display(Name = "Adress")]
        public int ResidenceId { get; set; }
        public List<SelectListItem> Residences { get; set; }
        [Display(Name = "Fastighetsnummer")]
        public string HousingNumber { get; set; }
        [Display(Name = "Tillgång med huvudnyckel")]
        public bool CanAccessResidence { get; set; }
    }
}
