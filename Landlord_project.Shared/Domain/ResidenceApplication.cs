using System.ComponentModel.DataAnnotations;

namespace Landlord_project.Shared.Domain
{
    public class ResidenceApplication : BaseEntity
    {
        public Tenant Tenant { get; set; }

        [Display(Name = "Innehar husdjur")]
        public bool HasPets { get; set; }

        [Display(Name = "Rökare?")]
        public bool IsSmoking { get; set; }

        [Display(Name = "Arbetsgivare")]
        [StringLength(100)]
        public string Employer { get; set; }

        [Display(Name = "Jobbtitel")]
        [StringLength(100)]
        public string CurrentWork { get; set; }

        [Display(Name = "Stad")]
        [StringLength(100)]
        [Required(ErrorMessage = "Stad måste anges")]
        public string City { get; set; }

        [Display(Name = "Postadress")]
        [Required]
        public string Address { get; set; }

        [Display(Name = "Postnummer")]
        [RegularExpression("^[0-9]*$")]
        [Required]
        public string ZipCode { get; set; }

        [Display(Name = "Nuvarande hyresvärd")]
        public string CurrentLandLord { get; set; }

        [Display(Name = "Hyresvärd nummer")]
        [RegularExpression("^[0-9]*$")]
        public string CurrentLandLordPhone { get; set; }

        [Display(Name = "Övrigt")]
        [DataType(DataType.MultilineText)]
        public string AdditionalText { get; set; }

        [Display(Name = "Accepterat regler")]
        public bool AgreeOnTerms { get; set; }
        public int ResidenceId { get; set; }
        public string ResidenceName { get; set; }
        public Residence Residence { get; set; }
    }
}
