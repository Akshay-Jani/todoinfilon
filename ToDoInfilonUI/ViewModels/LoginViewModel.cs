using System.ComponentModel.DataAnnotations;

namespace ToDoInfilonUI.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(6)]
        [MaxLength(12)]
        public string Password { get; set; }
    }
}
