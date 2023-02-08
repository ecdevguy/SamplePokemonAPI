using CobbleStone_API.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace CobbleStone_API.Controllers
{
    public class PokemonController : ApiController
    {
        private static readonly PokemonContext pokeContext = new PokemonContext();
        
        //List<Pokemon> pocketMon = new List<Pokemon>();
        // GET /<controller>
        //Returns all records
        public List<Pokemon> Get()
        {
            
            
            using (var db = new PokemonContext())
            {
                var result = (from p in db.Pokemons orderby p.PokemonId select p).ToList();
                return result;
            }           
        }
        // GET /<controller>{name}
        //Returns single record
        public List<Pokemon> GetPokemon(string name) 
        {
            

            using (var db = new PokemonContext())
            {
                var result = (from p in db.Pokemons where p.PokemonName == name select p).ToList();
                
                return result;
            }
        }
        //public List<Pokemon> GetPokemonFiltered([FromUri]Pokemon model) //I'm almost past the deadline, so I'm stopping here and commenting out unusable code
        //{
            
        //    using (var db = new PokemonContext())
        //    {             
        //        var result = (from p in db.Pokemons where p.Generation == model.Generation select p).ToList();
        //        return result;
        //    }
                
        //}

        //// POST api/<controller>
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}