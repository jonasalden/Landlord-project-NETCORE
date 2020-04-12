using Landlord_project.Data;
using Landlord_project.Data.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Landlord_project.Models
{
    public class ReportModel
    {
        [DataType(DataType.Text, ErrorMessage = "Ange förnamn i korrekt format")]
        [Required(ErrorMessage = "Du måste ange ett förnamn")]
        [Display(Name = "Förnamn *")]
        public string FirstName { get; set; }
        [DataType(DataType.Text, ErrorMessage = "Ange efternamn i korrekt format")]
        [Required(ErrorMessage = "Du måste ange ett efternamn")]
        [Display(Name = "Efternamn *")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Du måste ange ett telefonnummer")]
        [Display(Name = "Telefonnummer *")]
        [MaxLength(15, ErrorMessage = "För långt telefonnummer")]
        [MinLength(8, ErrorMessage = "För kort telefonnummer")]
        [RegularExpression("^[0-9,-]*$", ErrorMessage = "Ange telefonnummer i korrekt format")]
        public string Phone { get; set; }
        [EmailAddress(ErrorMessage = "Ange en giltig epostadress")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Felaktig längd på epostadressen")]
        [Required(ErrorMessage = "Du måste ange din epostadress")]
        [Display(Name = "Epostadress *")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Du måste ange en beskrivning av problemet")]
        [StringLength(1000, MinimumLength = 5, ErrorMessage = "Ange en välformulerad beskrivning")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Beskrivning av problem *")]
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }

        [FileExtensionAttribute(fileExtensions: "jpg,jpeg,png,tif", ErrorMessage = "Filformat som är tillåtna (jpg,jpeg,png,tif)")]
        [Display(Name = "Bifoga bild")]
        public IFormFile Image { get; set; }
        public string ImageName { get; set; }
        public byte[] ImageFile { get; set; }
        public string ImageMimeType { get; set; }
        [Display(Name = "Adress")]
        public int ResidenceId { get; set; }
        public List<SelectListItem> Residences { get; set; }
    }
}
