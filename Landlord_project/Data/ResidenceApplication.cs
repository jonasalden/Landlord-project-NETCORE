using System.ComponentModel.DataAnnotations;

namespace Landlord_project.Data
{
    public class ResidenceApplication
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Förnamn")]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Efternamn")]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Display(Name = "Telefonnummer")]
        [Required]
        [MaxLength(12)]
        [MinLength(6)]
        [RegularExpression("^[0-9]*$")]
        public string Phone { get; set; }

        [Display(Name = "Ålder")]
        [RegularExpression("^[0-9]*$")]
        [Required]
        public int Age { get; set; }

        [Display(Name = "Månadslön")]
        [Range(0, 999999.99)]
        [Required]
        public decimal Salary { get; set; }

        [Display(Name = "Personnummer")]
        [Required]
        public string SocialSecurityNumber { get; set; }

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
        [Required]
        public string City { get; set; }

        [Display(Name = "Postadress")]
        [Required]
        public string Address { get; set; }

        [Display(Name = "Postnummer")]
        [RegularExpression("^[0-9]*$")]
        [Required]
        public int ZipCode { get; set; }

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
    }
}
