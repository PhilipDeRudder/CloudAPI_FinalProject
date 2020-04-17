using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class DbInitializer
    {
        //onderstaand is voor zekerheid dat er iets in de database is aangemaakt.
        public static void Initialize(LibraryContext context)
        {
            //aanmaken van database indien deze nog niet bestaat
            context.Database.EnsureCreated();

            //indien er nog geen albums aanwezig zijn...
            if (!context.Albums.Any())
            {
                //album aanmaken
                var testAlbum = new Album()
                {
                    album_name = "TestAlbum"
                };

                //toevoegen van test album aan databank
                context.Albums.Add(testAlbum);
                //opslagen van de aanpassingen aan de db
                context.SaveChanges();
            }

               //indien er nog geen artiesten aanwezig zijn...
            if (!context.Artists.Any())
            {
                //album aanmaken
                var testArtist = new Artist()
                {
                    artist_name = "TestArtist"
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
                    track_name = "TestArtist"
                    
                };

                //toevoegen van testartiest aan databank
                context.Tracks.Add(testTrack);
                //opslagen van de aanpassingen aan de db
                context.SaveChanges();
            }



               
        }
    }
}