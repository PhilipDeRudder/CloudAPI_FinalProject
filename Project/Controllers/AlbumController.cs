using System.Diagnostics;
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
        /*
        [HttpGet]
        public List<Album> GetAllAlbums()
        {
            return context.Albums.ToList();
        }
        */

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
            
            orgAlb.Title = updateAlbum.Title;
            orgAlb.Genre = updateAlbum.Genre;
            context.SaveChanges();
            return Ok(orgAlb);
        

        }       

        
        
        [HttpGet]
        public List<Album> GetAllAlbums(string genre, string title, int? page,string sort, int length = 100, string dir = "asc")
        {
            IQueryable<Album> query = context.Albums;
            /////////PAGING///////////////
            if (!string.IsNullOrWhiteSpace(genre))
                query = query.Where(d => d.Genre == genre);
            if (!string.IsNullOrWhiteSpace(title))
                query = query.Where(d => d.Genre == title);

            if(page.HasValue)
                query = query.Skip(page.Value * length);
            query = query.Take(length);

             /////////PAGING///////////////

             ////////SORTING//////////////
            if(!string.IsNullOrWhiteSpace(sort))
            {
                switch(sort)
                {
                    case "genre":
                        if(dir == "asc")
                            query = query.OrderBy(d =>d.Genre);
                        else if(dir == "desc")
                            query = query.OrderByDescending(d => d.Genre);
                        
                    break;

                    case "title":
                        if(dir =="asc")
                            query = query.OrderBy(d => d.Title);
                        else if(dir == "desc")
                            query = query.OrderByDescending(d => d.Title);
                    break;

                    
                }


            }
            ////////SORTING//////////////


            return query.ToList();
          

        }
        
    





    }
}
