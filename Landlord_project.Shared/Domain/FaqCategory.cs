using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Landlord_project.Shared.Domain
{
    public class FaqCategory : BaseEntity
    {
        public string Name { get; set; }
        public FaqQuestion Question { get; set; }
    }
}
