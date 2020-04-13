using System.ComponentModel.DataAnnotations;

namespace Landlord_project.Data
{
    public class ResidenceApplication
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public string SocialSecurityNumber { get; set; }
        public bool HasPets { get; set; }
        public bool IsSmoking { get; set; }
        public string Employer { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }
        public string CurrentLandLord { get; set; }
        public string CurrentLandLordPhone { get; set; }
        public string AdditionalText { get; set; }
        public bool AgreeOnTerms { get; set; }
    }
}
