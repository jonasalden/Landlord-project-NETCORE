using System;
using System.Collections.Generic;

namespace Landlord_project.Data
{
    public class Residence
    {
        public int Id { get; set; }
        public string Estate { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int ZipCode { get; set; }
        public decimal RentalPrice { get; set; }
        public int Rooms { get; set; }
        public int Size { get; set; }
        public string HousingNumber { get; set; }
        public int FloorNumber { get; set; }
        public bool CanRental { get; set; }
        public DateTime ShowFrom { get; set; }
        public DateTime ShowTo { get; set; }
        public DateTime ApplicationFrom { get; set; }
        public ResidenceGroupType TypeOfResidence { get; set; }
        public string Area { get; set; }
        public DateTime DateBuilt { get; set; }
        public DateTime DateRenovated { get; set; }
        public bool Featured { get; set; }
        public string ImageName { get; set; }
        public byte[] ImageFile { get; set; }
        public string ImageMimeType { get; set; }
        public ICollection<ResidenceAssignment> ResidenceAssignments { get; set; }
        public ICollection<ResidenceReport> ResidenceReports { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public bool HasElevator { get; set; }
        public bool HasBalcony { get; set; }
        public bool HasCourtyard { get; set; }
    }
}
