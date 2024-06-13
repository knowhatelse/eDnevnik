using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eDnevnik___backend.Entities
{
    public class School
    {
        [Key]
        public int Id { get; set; }
        public string SchoolName { get; set; } = null!;
        public string SchoolType { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Fax { get; set; } = null!;

        public ICollection<Class> Classes { get; } = new List<Class>();

        [ForeignKey("Admin")]
        public int AdminId { get; set; }
        public Admin Admin { get; set; } = null!;
    }
}
