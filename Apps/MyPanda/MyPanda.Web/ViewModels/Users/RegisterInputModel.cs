using SIS.MvcFramework.Attributes.Validation;

namespace MyPanda.Web.ViewModels.Users
{
    public class RegisterInputModel
    {
        [RequiredSis]
        [StringLengthSis(5,20, "Username should be betweem 5 amd 20 characters")]
        public string Username { get; set; }

        [RequiredSis]
        [StringLengthSis(5, 20, "Email should be betweem 5 amd 20 characters")]
        public string Email { get; set; }

        [RequiredSis]
        public string Password { get; set; }

        [RequiredSis]
        public string ConfirmPassword { get; set; }
    }
}
