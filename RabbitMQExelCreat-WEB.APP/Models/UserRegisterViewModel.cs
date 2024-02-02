using System.ComponentModel.DataAnnotations;

namespace RabbitMQExelCreat_WEB.APP.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage ="kulanıcı adı boş geçilemez")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "şifre boş geçilemez")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Email boş geçilemez")]
        public string Email { get; set; }
    }
}
