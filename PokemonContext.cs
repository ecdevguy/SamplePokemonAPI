using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CobbleStone_API.Models
{
    public class PokemonContext : DbContext
    {
        public PokemonContext() : base("name=PokemonDB")
        {
            //I'm unfamiliar with how the database will be created outside of my enviornment, so I will have it re-created each time the application is ran.
            Database.SetInitializer<PokemonContext>(new DropCreateDatabaseAlways<PokemonContext>());
        }
        public DbSet<Pokemon> Pokemons { get;set; }
    }
}