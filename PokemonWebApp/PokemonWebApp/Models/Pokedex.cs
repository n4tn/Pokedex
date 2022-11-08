using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokemonWebApp.Models
{
    public class Pokedex
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = "";
        [Required]
        public string Types { get; set; } = "";
        //public Type SecondaryType { get; set; }
        public double? Height { get; set; }
        public double? Weight { get; set; }
        public string? Gender { get; set; }

        public string Weakness { get; set; } = "";

        [ForeignKey("Evolution")]
        public string? Evolution { get; set; }

    }
}
