using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PokemonWebApp.Models;

namespace PokemonWebApp.Data
{
    public class PokemonWebAppContext : DbContext
    {
        public PokemonWebAppContext (DbContextOptions<PokemonWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<PokemonWebApp.Models.Pokedex> Pokedex { get; set; } = default!;
    }
}
