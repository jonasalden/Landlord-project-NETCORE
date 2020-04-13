using System;
using System.ComponentModel.DataAnnotations;

namespace Landlord_project.Models
{
    public class ResidenceDetailModel
    {
        public int Id { get; set; }
        public string Image { get; set; }
        [Display(Name = "Adress:")]
        public string Address { get; set; }
        [Display(Name = "Område:")]
        public string Area { get; set; }
        [Display(Name = "Antal rum:")]
        public int Rooms { get; set; }
        [Display(Name = "Boarea:")]
        public int Size { get; set; }
        [Display(Name = "Månadshyra:")]
        public decimal RentalPrice { get; set; }
        [Display(Name = "Tillgänglig från:")]
        public string AvailableFrom { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        [Display(Name = "Lägenhetsnr:")]
        public string HousingNumber { get; set; }
        [Display(Name = "Våning:")]
        public int FloorNumber { get; set; }
        [Display(Name = "Byggt år:")]
        public DateTime DateBuilt { get; set; }
        [Display(Name = "Renoverat år:")]
        public DateTime DateRenovated { get; set; }
        public int ZipCode { get; set; }
    }
}
