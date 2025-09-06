namespace THosCase.Business
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Login Model
    /// </summary>
    public class LoginModel
    {
        [Required(ErrorMessage = "Kullanıcı adı zorunludur")]
        [Display(Name = "Kullanıcı Adı")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
    }
}
