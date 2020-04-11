using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Landlord_project.Data
{
    public class Tenant
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        //public string FullName { get { return FirstName + " " + LastName; } } // VyModel ist.
        public bool HasResidence { get; set; }
        public ICollection<ResidenceAssignment> ResidenceAssignments { get; set; }
    }
}
