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


        //werkt
        //gegevens opvragen
        //opvragen van alle tracks
        [HttpGet] //api/v1/tracks
        public List<Track> GetallTracks(){
            return context.Tracks.ToList();

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

        //tested --> werkt
        //aanpassen van een object.
        //eerst properties van object aanpassen en vervolgens wijzigingen bewaren.

        [HttpPut]
        public IActionResult UpdateTrack([FromBody] Track updateTrack){

            var track = context.Tracks.Find(updateTrack.Id);

            if(track == null)
            return NotFound();


            track.track_name = updateTrack.track_name;
            track.genre = updateTrack.genre;
            track.track_time = updateTrack.track_time;

            context.SaveChanges();

            return Ok(track);
            
        }


    }
}
