using System.ComponentModel.DataAnnotations;

namespace Landlord_project.Data
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
