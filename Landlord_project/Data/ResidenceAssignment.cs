﻿namespace Landlord_project.Data
{
    public class ResidenceAssignment
    {
        public int TenantID { get; set; }
        public int ResidenceID { get; set; }
        public Tenant Tenant { get; set; }
        public Residence Residence { get; set; }
    }
}
