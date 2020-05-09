using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class DbInitializer
    {
        //onderstaand is voor zekerheid dat er iets in de database is aangemaakt.
        public static void Initialize(MusicContext context)
        {
            //aanmaken van database indien deze nog niet bestaat
            context.Database.EnsureCreated();

            //indien er nog geen albums aanwezig zijn...
            if (!context.Albums.Any())
            {
                //album aanmaken
                var albumE1 = new Album()
                {
                    album_title = "Infinite",
                    album_genre = "hip-hop",
                    release_date = new DateTime(1996,11,12) 
                   
                   
                };
                
               context.Albums.Add(albumE1);
               context.SaveChanges();
                
            }

               //indien er nog geen artiesten aanwezig zijn...
            if (!context.Artists.Any())
            {
                //album aanmaken
                var testArtist = new Artist()
                {
                  
                    artist_name = "Eminem"
                };

                //toevoegen van testartiest aan databank
                context.Artists.Add(testArtist);
                //opslagen van de aanpassingen aan de db
                context.SaveChanges();
            }

                 //indien er nog geen artiesten aanwezig zijn...
            if (!context.Tracks.Any())
            {
                //album aanmaken
                var testTrack = new Track()
                {
                
                    track_name = "Infinite",
                    genre = "hiphop"
                    
                };

                //toevoegen van testartiest aan databank
                context.Tracks.Add(testTrack);
                //opslagen van de aanpassingen aan de db
                context.SaveChanges();
            }

            
           
        
        }
    }
}