using System.ComponentModel.DataAnnotations;

namespace StudentRegister.Models
{
    public class Student
    {
        [Required, StringLength(10)]
        public string StudentId { get; set; }

        [Required, StringLength(50)]
        public string FirstName { get; set; }

        [Required, StringLength(50)]
        public string LastName { get; set; }

        [Required, EmailAddress, StringLength(100)]
        public string Email { get; set; }

        [Required, StringLength(50)]
        public string Department { get; set; }

        [Required, StringLength(50)]
        public string Level { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
    }
}
