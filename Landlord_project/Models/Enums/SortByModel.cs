using System.ComponentModel.DataAnnotations;

namespace Landlord_project.Models.Enums
{
    public enum SortByModel
    {
        [Display(Name = "Tillgänglighet")]
        Availability = 1,
        [Display(Name = "Hyra lägst")]
        RentFrom = 2,
        [Display(Name = "Hyra högst")]
        RentTo = 3,
        [Display(Name = "Storlek")]
        Size = 4,
        [Display(Name = "Antal rum")]
        Rooms = 5,
    }
}
