using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class UserViewModel
    {
        public string? Id { get; set; }

        [Required]
        [Display(Name = "اسم المستخدم")]
        public string UserName { get; set; } = null!;

        [Required, EmailAddress]
        [Display(Name = "البريد الإلكتروني")]
        public string Email { get; set; } = null!;

        [Display(Name = "كلمة المرور")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name = "الدور")]
        [Required(ErrorMessage = "الرجاء اختيار الدور")]
        public string SelectedRole { get; set; } = null!;

        public List<string> Roles { get; set; } = new();
    }
}
