


using System.ComponentModel.DataAnnotations;

namespace csharp_gregslist.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string Description { get; set; }
        public string ImgUrl { get; set; }

    }
}