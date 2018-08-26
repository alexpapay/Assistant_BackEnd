using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AssistantWebMySql.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [DisplayName("Электронная почта")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Пароль")]
        public string Password { get; set; }
    }
}