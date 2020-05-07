using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Controllers
{
    [Route("api/v1/artists")]
    public class ArtistController : Controller
    {
      private readonly MusicContext context;

        public ArtistController(MusicContext context){
            
            this.context = context;
        }

        //Alle artiesten opvragen (SELECT/READ)
        [HttpGet]
        public List<Artist> GetAllArtist()
        {
            return context.Artists.ToList();
        }

        //artist opvragen adhv naam 
        [HttpGet]
        public IActionResult GetArtistByName(string name)
        {
            IQueryable<Artist> query = context.Artists;

            if(!string.IsNullOrWhiteSpace(name))
                query = query.Where(d => d.artist_name == name);
            
            return Ok(query);
        }

       


        //Object opvragen adhv ID + relaties mee ophalen
        [Route("{id}")]
        [HttpGet]
        public IActionResult GetArtist(int id)
        {
            var artist = context.Artists
                                .Include(d => d.Albums)
                                .SingleOrDefault(d => d.ArtisId == id);
            if(artist == null)
                return NotFound();

            return Ok(artist);
        }

         //nieuw album aanmaken(CREATE)
        [HttpPost]
        public IActionResult CreatArtist([FromBody] Artist newArtist)
        {
            context.Artists.Add(newArtist);

            context.SaveChanges();
            return Created("", newArtist);
        }


        //verwijderen adhv id (DELETE)

        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeleteArtist(int id)
        {
            var artist = context.Artists.Find(id);
            if(artist == null)
                return NotFound();
            
            context.Artists.Remove(artist);
            context.SaveChanges();

            //standaard 204 bij gelukte delete
            return NoContent();

        }


        //aanpassen(UPDATE)
        [HttpPut]
        public IActionResult UpdateArtist([FromBody] Artist updateArtist)
        {
            var orgArtist = context.Artists.Find(updateArtist.ArtisId);
                if(orgArtist == null)
                    return NotFound();

                orgArtist.artist_name = updateArtist.artist_name;
                

                context.SaveChanges();
                return Ok(orgArtist);
        }






       
        
    }
}
