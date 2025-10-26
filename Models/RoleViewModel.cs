using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class RoleViewModel
    {
        public string? Id { get; set; }

        [Required(ErrorMessage = "اسم الدور مطلوب")]
        [Display(Name = "اسم الدور")]
        public string? Name { get; set; }
    }
}
