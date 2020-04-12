using System.ComponentModel.DataAnnotations;

namespace Landlord_project.Models
{
    public class ResidenceModel
    {
        public int Id { get; set; }
        public string Image { get; set; }
        [Display(Name = "Adress:")]
        public string Address { get; set; }
        [Display(Name = "Område:")]
        public string Area { get; set; }
        [Display(Name = "Antal rum:")]
        public int Rooms { get; set; }
        [Display(Name = "Storlek:")]
        public int Size { get; set; }
        [Display(Name = "Månadshyra:")]
        public decimal RentalPrice { get; set; }
        [Display(Name = "Tillgänglig från:")]
        public string AvailableFrom { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}
