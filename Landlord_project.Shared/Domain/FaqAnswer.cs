using Landlord_project.Shared.Domain;

namespace Landlord_project.Shared.Domain
{
    public class FaqAnswer : BaseEntity
    {
        public string Answer { get; set; }
        public FaqQuestion Question { get; set; }
    }
}
