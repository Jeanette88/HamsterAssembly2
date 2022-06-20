using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamsterAssembly2.Shared.Models
{
    public class Hamster
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter a name.")]
        [MinLength(2, ErrorMessage = "At least two characters.")]
        public string? Name { get; set; }

        [Range(1, 5, ErrorMessage = "Age must be between 1 and 5.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Enter favourite food.")]
        [MinLength(3, ErrorMessage = "At least three characters.")]
        public string? FavFood { get; set; }

        [Required(ErrorMessage = "Enter favourite thing.")]
        [MinLength(3, ErrorMessage = "At least three characters.")]
        public string? Loves { get; set; }
        [Required(ErrorMessage = "An image is required.")]
        [MinLength(5, ErrorMessage = "At least five characters.")]
        public string? ImgName { get; set; }
        public int Wins { get; set; } = 0;
        public int Losses { get; set; } = 0;
        public int Games { get; set; } = 0;
    }
}
