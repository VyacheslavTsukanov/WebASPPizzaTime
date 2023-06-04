using System.ComponentModel.DataAnnotations;

namespace WebASPPizzaTimeLessons.Models
{
    public class Commodity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The name field cannot be null!!!")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$", ErrorMessage = "Please, enter a Valid Email.")]
       
        public string Email { get; set; }
        public string PhotoPath { get; set; }
        public Dept? Department { get; set; }
    }
}
