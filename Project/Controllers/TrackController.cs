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
    [Route("api/v1/tracks")]
    public class TrackController : Controller
    {
      private readonly MusicContext context;

        public TrackController(MusicContext context){
            
            this.context = context;
        }


   
        

        //tested --> werkt
        //gegevens toevoegen
        [HttpPost]//api/v1/tracks
        public IActionResult CreateTrack([FromBody] Track newTrack){

            //toevoegen van de nieuwe track in de databank + id
            //niet ingevulde waardes krijgen 'null' in database
            context.Tracks.Add(newTrack);
            context.SaveChanges();

            //stuurt result 201 met de track als conten

            return Created("", newTrack);
        }

        //opvragen van track adhv id dmv find methode
        //relatie wordt niet mee opgehaald met find
        [Route("{id}")]
        [HttpGet]

        public IActionResult GetTrack(int id){

            var track = context.Tracks.Find(id);
            if(track == null)
            return NotFound(); // indien niet gevonden , error 404


            return Ok(track);
        }

        //




        //optie?-->delete tracks adhv naam 
        //verwijderen van een object
        //eerst opzoeken met find adhv id vervolgens verwijder met remove en opslagen
        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeleTrack(int id){

            var track = context.Tracks.Find(id);
            if(track == null){
                return NotFound();
            }
            else{
                context.Tracks.Remove(track);
                context.SaveChanges();

                return NoContent();

            }


        }

        //paging+sorting

        [HttpGet]
        public List<Track> GetAllTracks(string genre, string name, int? page,string sort, int length = 2, string dir = "asc")
        {
            /////PAGING////////
            IQueryable<Track> query = context.Tracks;

            if(!string.IsNullOrWhiteSpace(genre))
            query =query.Where(d => d.genre == genre);
            if(!string.IsNullOrWhiteSpace(name))
            query = query.Where(d => d.track_name == name);

            if(page.HasValue)
                query = query.Skip(page.Value * length);
            query = query.Take(length);
            /////PAGING////////


            ////////SORTING/////////
            if(!string.IsNullOrWhiteSpace(sort))
            {
                switch(sort)
                {
                    case "title":
                        if(dir == "asc")
                            query = query.OrderBy(d => d.track_name);
                        else if (dir == "desc")
                            query = query.OrderByDescending(d => d.track_name);
                    break;
                    
                }

            }

            return query.ToList();


        }


        

       


    }
}
