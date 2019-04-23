using System.ComponentModel.DataAnnotations;

namespace FastFood.Web.ViewModels.Employees
{
    public class RegisterEmployeeInputModel
    {
        [Required]
        [MinLength(3), MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [Range(18, 64)]
        public int Age { get; set; }

        public string PositionName { get; set; }

        //public string PositionName { get; set; }

        [Required]
        [MinLength(3), MaxLength(30)]
        public string Address { get; set; }
    }
}
