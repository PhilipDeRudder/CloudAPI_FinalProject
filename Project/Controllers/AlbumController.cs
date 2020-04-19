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


        //specifiek album opvragen + relaties mee ophalen adhv id
        [Route("{id}")]
        [HttpGet]
        public IActionResult getAlbum(int id)
        {
            //zoeken naar een bepaald album
            var album = context.Albums
                            .Include(d => d.Artist)
                            .SingleOrDefault( d => d.Id == id);


            //indien niet gevonden 404
            if(album == null)
                return NotFound();

            //anders ist inordeuhhhh
            return Ok(album);
        }

        //zoeken op genre, titel of artiest
        // api/v1/albums?genre=d&b
        // api/v1/albums?artist=netsky
        // api/v1/albums?title=titel
        //TODO: PAGING????
        [HttpGet]
        public List<Album> GetAlbums(string genre, string artist, string title)
        {
            IQueryable<Album> query = context.Albums;

            if(!string.IsNullOrWhiteSpace(genre))
                query = query.Where(d => d.album_genre ==genre);
            if(!string.IsNullOrWhiteSpace(artist))
                query = query.Where(d => d.Artist.artist_name == artist);
            if(!string.IsNullOrWhiteSpace(title))
                query = query.Where(d => d.album_title == title);

            
                return query.ToList();
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
            var orgAlb = context.Albums.Find(updateAlbum.Id);
            if(orgAlb == null)
                return NotFound();
            
            orgAlb.album_title = updateAlbum.album_title;
            orgAlb.album_genre = updateAlbum.album_genre;
            context.SaveChanges();
            return Ok(orgAlb);
        

        }       


        

        
    }
}
