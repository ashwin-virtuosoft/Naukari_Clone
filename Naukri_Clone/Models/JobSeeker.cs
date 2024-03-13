namespace Naukri_Clone.Models
{
    public class JobSeeker
    {
        public int SeekerId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
