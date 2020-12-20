using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Landlord_project.Shared.Domain
{
    public class Tenant : BaseEntity
    {
        [Display(Name = "Förnamn")]
        public string FirstName { get; set; }
        [Display(Name = "Efternamn")]
        public string LastName { get; set; }
        [Display(Name = "Epostadress")]
        public string Email { get; set; }
        [Display(Name = "Telefonnummer")]
        public string Phone { get; set; }
        [Display(Name = "Ålder")]
        public int Age { get; set; }
        [Display(Name = "Lön")]
        public decimal Salary { get; set; }
        [Display(Name = "Personnummer")]
        public string SocialSecurityNumber { get; set; }
        [Display(Name = "Arbetsgivare")]
        public string Employer { get; set; }
        public bool HasResidence { get; set; }
        public ICollection<ResidenceAssignment> ResidenceAssignments { get; set; }
    }
}
