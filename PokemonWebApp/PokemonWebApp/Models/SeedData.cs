using Microsoft.EntityFrameworkCore;
using PokemonWebApp.Data;

namespace PokemonWebApp.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PokemonWebAppContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PokemonWebAppContext>>()))
            {
                if (context.Pokedex.Any())
                {
                    return; // Seed the database
                }

                context.Pokedex.AddRange(
                    new Pokedex
                    {
                        Name = "Bulbasaur",
                        Types = "Grass + Poision",
                        Height = 0.7,
                        Weight = 6.9,
                        Gender = "Male",
                        Weakness = "Fire + Psychic + Flying + Ice"

                    },
                    new Pokedex
                    {
                        Name = "Ivysaur",
                        Types = "Grass + Poision",
                        Height = 1,
                        Weight = 13,
                        Gender = "Male",
                        Evolution = "Bulbasaur",
                        Weakness = "Fire + Psychic + Flying + Ice"

                    }, 
                    new Pokedex
                    {
                        Name = "Venusaur",
                        Types = "Grass + Poision",
                        Height = 2,
                        Weight = 100,
                        Gender = "Male",
                        Evolution = "Ivysaur",
                        Weakness = "Fire + Psychic + Flying + Ice"
                    });
                context.SaveChanges();
            }
        }
    }
}

