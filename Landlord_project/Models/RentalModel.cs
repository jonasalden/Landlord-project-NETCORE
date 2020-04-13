using System.Collections.Generic;

namespace Landlord_project.Models
{
    public class RentalModel
    {
        public List<ResidenceModel> Residence { get; set; }
        public int NumResidences { get; set; }
        public decimal MinRent { get; set; }
        public decimal MaxRent { get; set; }
        public int MaxRooms { get; set; }

        public RentalModel()
        {
            Residence = new List<ResidenceModel>();
        }
    }
}
