namespace Naukri_Clone.Models
{
    public class Employer
    {
        public int EmpId { get; set; }
        public string EFName { get; set; }
        public string ELName { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Designation { get; set; }
        public string OrganizationName { get; set; }
    }
}
