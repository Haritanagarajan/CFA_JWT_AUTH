using System.ComponentModel.DataAnnotations;

namespace UserManagement.Data.Models

{
    public class UserDetailsModel
    {
        [Key]
        public int UserId { get; set; }

        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Username should only contain letters")]
        [StringLength(15, ErrorMessage = "Username should be at most 15 characters")]
        public string? UserName { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Password must meet complexity requirements")]
        public string? Password { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email format")]
        [StringLength(100, ErrorMessage = "Email should be at most 100 characters")]
        public string? UserEmail { get; set; }

        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Contact should contain 10 digits")]
        public long UserContact { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Birth")]
        [Range(typeof(DateTime), "1900-01-01", "2099-12-31", ErrorMessage = "Date of birth must be between 1900 and 2099")]
        public DateTime? UserDob { get; set; }
    }
}
