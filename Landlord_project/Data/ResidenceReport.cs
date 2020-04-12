using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Landlord_project.Data
{
    public class ResidenceReport
    {
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
    }
}
