using System.ComponentModel.DataAnnotations;

namespace Landlord_project.Shared.Domain
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
