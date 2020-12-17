namespace Landlord_project.Data
{
    public class FaqAnswer : BaseEntity
    {
        public string Answer { get; set; }
        public FaqQuestion Question { get; set; }
    }
}
