using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Landlord_project.Data
{
    public class Tenant : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string Employer { get; set; }
        public bool HasResidence { get; set; }
        public ICollection<ResidenceAssignment> ResidenceAssignments { get; set; }
    }
}
