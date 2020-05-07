using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using Microsoft.EntityFrameworkCore;

namespace Controllers
{
    [Route("api/v1/albums")]
    public class AlbumController : Controller
    {
      private readonly MusicContext context;

        public AlbumController(MusicContext context){
            
            this.context = context;
        }

        //Alle Gegevens opvragen (SELECT/READ)
        [HttpGet]
        public List<Album> GetAllAlbums()
        {
            return context.Albums.ToList();
        }

        //nieuw album aanmaken(CREATE)
        [HttpPost]
        public IActionResult CreatAlbum([FromBody] Album newAlbum)
        {
            context.Albums.Add(newAlbum);
            context.SaveChanges();
            return Created("", newAlbum);
        }


       

        //Album verwijderen (DELETE)
        [Route("id")]
        [HttpDelete]
        public IActionResult deleteAlbum(int id)
        {
            var album = context.Albums.Find(id);
            if(album == null)
                return NotFound();

            context.Albums.Remove(album);
            context.SaveChanges();
            return NoContent();    
        
        }

        //todo: zien dat de track ook aangepast worden.
        //een update aanpassen (UPDATE)
       
        [HttpPut]
        public IActionResult updateAlbum([FromBody] Album updateAlbum)
        {
            var orgAlb = context.Albums.Find(updateAlbum.AlbumId);
            if(orgAlb == null)
                return NotFound();
            
            orgAlb.album_title = updateAlbum.album_title;
            orgAlb.album_genre = updateAlbum.album_genre;
            context.SaveChanges();
            return Ok(orgAlb);
        

        }       


        

        
    }
}
