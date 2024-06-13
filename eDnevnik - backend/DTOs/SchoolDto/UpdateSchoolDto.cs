namespace eDnevnik___backend.DTOs.SchoolDto
{
    public class UpdateSchoolDto
    {
        public string SchoolName { get; set; } = null!;
        public string SchoolType { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Fax { get; set; } = null!;
    }
}
