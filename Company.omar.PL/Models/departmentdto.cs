using System.ComponentModel.DataAnnotations;

namespace Company.omar.PL.Models
{
    public class departmentdto
    {
        [Required(ErrorMessage = "Code is required")]
        public string code { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "CreatedAt is required")]
        public DateTime CreatedAt { get; set; }
    }
}
