using System.ComponentModel.DataAnnotations;

namespace LearnDotNetCore.Models
{
    public class Employee : BaseModel
    {
        [Required, MaxLength(50)]
        public  string  FirstName { get; set; }
        public  string  LastName { get; set; }
        public  long  PhoneNumber { get; set; }
        public  int  NationalId { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
            ErrorMessage ="Invalid email, wrong format")]
        public  string  Email { get; set; }
        public  Department?  Department { get; set; }
        public  string  PhotoPath { get; set; }
    }
}
