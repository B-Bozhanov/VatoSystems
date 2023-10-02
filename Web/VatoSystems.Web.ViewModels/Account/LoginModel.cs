namespace VatoSystems.Web.ViewModels.Account
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Authentication;

    using static VatoSystems.Common.GlobalConstants.Account;

    public class LoginModel
    {
        [Required]
        [MaxLength(UsernameMaxLength)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }
    }
}
