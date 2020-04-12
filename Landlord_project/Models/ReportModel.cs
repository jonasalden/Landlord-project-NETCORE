using Landlord_project.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Landlord_project.Models
{
    public class ReportModel
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Du måste ange ett förnamn")]
        [Display(Name = "Förnamn")]
        public string FirstName { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Du måste ange ett efternamn")]
        [Display(Name = "Efternamn")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Du måste ange ett telefonnummer")]
        [Display(Name = "Telefonnummer")]
        public string Phone { get; set; }
        [EmailAddress]
        [StringLength(100, MinimumLength = 3)]
        [Required(ErrorMessage = "Du måste ange en giltig epostadress")]
        [Display(Name = "Epostadress")]
        public string Email { get; set; }
        [Required]
        [StringLength(1000, MinimumLength = 5)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Beskrivning av problem")]
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public IFormFile Image { get; set; }
        public string ImageName { get; set; }
        public byte[] ImageFile { get; set; }
        public string ImageMimeType { get; set; }
        public int ResidenceId { get; set; }
        public List<SelectListItem> Residences { get; set; }
    }
}
