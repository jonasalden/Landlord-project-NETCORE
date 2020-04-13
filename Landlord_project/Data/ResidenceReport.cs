using System;
using System.ComponentModel.DataAnnotations;

namespace Landlord_project.Data
{
    public class ResidenceReport
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public string ImageName { get; set; }
        public byte[] ImageFile { get; set; }
        public string ImageMimeType { get; set; }
        public Residence Residence { get; set; }
        public int ResidenceId { get; set; }
        public string HousingNumber { get; set; }
        public bool CanAccessResidence { get; set; }
    }
}
