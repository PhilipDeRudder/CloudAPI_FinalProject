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
            if(!ModelState.IsValid){
    
                return BadRequest(ModelState);
            }
            
            context.Albums.Add(newAlbum);
            context.SaveChanges();
            return Created("", newAlbum);
        
        }



        

        //Album verwijderen (DELETE)
        [Route("{id}")]
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
            if(!ModelState.IsValid){
    
                return BadRequest(ModelState);
            }

            var orgAlb = context.Albums.Find(updateAlbum.AlbumId);
            if(orgAlb == null){
                return NotFound();
            }
            
            orgAlb.Title = updateAlbum.Title;
            orgAlb.Genre = updateAlbum.Genre;
            orgAlb.ArtistId = updateAlbum.ArtistId;
            orgAlb.release_date = updateAlbum.release_date;
            context.SaveChanges();
            return Ok(orgAlb);
        
        }       

        


        
        [HttpGet]
        public List<Album> GetAllAlbums(string genre, string title, int? page,string sort, int length = 100, string dir = "asc")
        {
            IQueryable<Album> query = context.Albums;
          ///////// Filtering /////////
            if (!string.IsNullOrWhiteSpace(genre))
                query = query.Where(d => d.Genre == genre);
            if (!string.IsNullOrWhiteSpace(title))
                query = query.Where(d => d.Genre == title);
        /////// Filtering //////////

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
              /////////PAGING///////////////

            if(page.HasValue)
                query = query.Skip(page.Value * length);
            query = query.Take(length);

             /////////PAGING///////////////

          


            return query.ToList();
          

        }
        
    
       


        //Object opvragen adhv ID + relaties mee ophalen
        [Route("{id}")]
        [HttpGet]
        public IActionResult GetAlbumsByAlbumId(int id =1)
        {
            var album = context.Albums.Find(id);
            if(album == null)
                return NotFound();




            return Ok(album);
        }

        [Route("artist")]
        [HttpGet]
        public IActionResult GetAlbumAndArtist(int idin){
            var albwithartist = context.Albums
                                .Include(d => d.Artist).Where(d => d.ArtistId == idin);
                            
                                
                                


            if(albwithartist == null)
                return NotFound();
            
            return Ok(albwithartist);   

        }







    }
}
