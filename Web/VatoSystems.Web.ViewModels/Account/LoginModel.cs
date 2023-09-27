namespace VatoSystems.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    using static VatoSystems.Common.GlobalConstants.Account;

    public class LoginModel
    {
        [Required]
        [MaxLength(UsernameMaxLength)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
