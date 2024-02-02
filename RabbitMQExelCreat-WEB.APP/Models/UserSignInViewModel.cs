using System.ComponentModel.DataAnnotations;

namespace RabbitMQExelCreat_WEB.APP.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage="lütfen kullanıcı adını giriniz")]
        public string username { get; set; }
        [Required(ErrorMessage = "lütfen şifreyi giriniz")]
        public string password { get; set; }

    }
}
