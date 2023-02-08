using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsvHelper.Configuration;

namespace CobbleStone_API.Models
{
    [Table("Pokemon")]
    public class Pokemon
    {
        public int PokemonId { get; set; }
        [Key]
        public string PokemonName { get; set; }
        public string Type1 { get; set; } //I suppose I could create enum type for Type1 & Type2 but strings are easier for me to work with.
        public string Type2 { get; set; }
        public int Total { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpecialAttack { get; set; }
        public int SpecialDefense { get; set;}
        public int Speed { get; set; }
        public int Generation { get; set; }
        public bool Legendary { get; set; }
    }
//#,Name,Type 1,Type 2,Total,HP,Attack,Defense,Sp. Atk,Sp. Def,Speed,Generation,Legendary
    sealed class PokemonMap : ClassMap<Pokemon>
    {
        public PokemonMap()
        {
            Map(m => m.PokemonId).Name("#");
            Map(m => m.PokemonName).Name("Name");
            Map(m => m.Type1).Name("Type 1");
            Map(m => m.Type2).Name("Type 2");
            Map(m => m.Total).Name("Total");
            Map(m => m.HP).Name("HP");
            Map(m => m.Attack).Name("Attack");
            Map(m => m.Defense).Name("Defense");
            Map(m => m.SpecialAttack).Name("Sp. Atk");
            Map(m => m.SpecialDefense).Name("Sp. Def");
            Map(m => m.Speed).Name("Speed");
            Map(m => m.Generation).Name("Generation");
            Map(m => m.Legendary).Name("Legendary");
        }
    }
}