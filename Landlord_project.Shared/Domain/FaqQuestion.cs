using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Landlord_project.Shared.Domain
{
    public class FaqQuestion : BaseEntity
    {
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public int AnswerId { get; set; }
        public FaqCategory Category { get; set; }
        public FaqAnswer Answer { get; set; }
    }
}
