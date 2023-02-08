using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using CobbleStone_API.Models;
using CsvHelper;
using CsvHelper.Configuration;

namespace CobbleStone_API
{
    public static class PopulatePokemonDB
    {
        static string csvName = HttpContext.Current.Server.MapPath("~/CSV/pokemon.csv");
        public static List<Pokemon> PopulateDB()
        {
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                HasHeaderRecord = true,

            };
            List<Pokemon> pokemon = new List<Pokemon>();
            PokemonContext pokemonDB = new PokemonContext();
            using (StreamReader reader = new StreamReader(csvName))
            using (var csv = new CsvReader(reader, configuration))
            {
                csv.Context.RegisterClassMap<PokemonMap>();
                pokemon = csv.GetRecords<Pokemon>().ToList();
                foreach (var poke in pokemon) //Would like to seperate this into a method so filter params could be passed
                {
                    if (poke.Legendary == true)
                    {
                        continue;
                    }
                    if (poke.Type1 == "Ghost" || poke.Type2 == "Ghost")
                    {
                        continue;
                    }
                    if (poke.Type1 == "Steel" || poke.Type2 == "Steel")
                    {
                        poke.HP += poke.HP;
                    }
                    if (poke.Type1 == "Fire" || poke.Type2 == "Fire")
                    {
                        poke.Attack = (int)((double)poke.Attack * .9);
                    }
                    if (poke.Type1 == "Bug" && poke.Type2 == "Flying")
                    {
                        poke.Speed = (int)((double)poke.Speed * 1.1);
                    }
                    if (poke.PokemonName.StartsWith("G"))
                    {
                        var letterAmount = poke.PokemonName.Length; //Don't need logic to exclude "G" as .Length starts from 0
                        var defenseIncrease = letterAmount * 5;
                        poke.Defense = poke.Defense + defenseIncrease;
                    }
                    poke.Total = poke.Attack + poke.SpecialAttack + poke.Defense + poke.SpecialDefense + poke.Speed + poke.HP;
                    pokemonDB.Pokemons.Add(poke);
                }
                pokemonDB.SaveChanges();

                return null;
                
            }
        }
    }
}