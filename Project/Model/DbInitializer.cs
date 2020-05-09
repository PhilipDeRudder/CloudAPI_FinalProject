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
            
            //indien er nog geen albums aanwezig zijn...
            if (!context.Albums.Any())
            {
              

                ICollection<Album> AlbumList = new List<Album>(){
                    new Album(){
                    album_title = "Infinite",
                    album_genre = "hip-hop",
                    release_date = new DateTime(1996,11,12),
                    ArtistId = 1
                    },

                    new Album(){
                        album_title = "Slim Shady EP",
                        album_genre = "hip-hop",
                        release_date = new DateTime(1997, 12, 16),
                        ArtistId = 1

                    },

                     new Album(){
                        album_title = "The Slim Shady LP",
                        album_genre = "hip-hop",
                        release_date = new DateTime(1999, 2, 22),
                        ArtistId = 1

                    },
                    //datums

                     new Album(){
                        album_title = "The Marshal Mathers LP",
                        album_genre = "hip-hop",
                        release_date = new DateTime(2000, 5, 23),
                        ArtistId = 1

                    },

                      new Album(){
                        album_title = "The Marshal Mathers LP-Tour edition",
                        album_genre = "hip-hop",
                        release_date = new DateTime(2002, 1, 1),
                        ArtistId = 1

                    },
                    
                      new Album(){
                        album_title = "The Eminem Show",
                        album_genre = "hip-hop",
                        release_date = new DateTime(2002, 5, 26),
                        ArtistId = 1

                    },

                    new Album(){
                        album_title = "The Singles",
                        album_genre = "hip-hop",
                        release_date = new DateTime(2003, 12, 23),
                        ArtistId = 1

                    },

                  new Album(){
                        album_title = "Encore",
                        album_genre = "hip-hop",
                        release_date = new DateTime(2004, 11, 12),
                        ArtistId = 1

                    },
                  new Album(){
                        album_title = "Curtain Call",
                        album_genre = "hip-hop",
                        release_date = new DateTime(2005, 12, 6),
                        ArtistId = 1

                    },

                  new Album(){
                        album_title = "Relapse",
                        album_genre = "hip-hop",
                        release_date = new DateTime(2009, 5, 15),
                        ArtistId = 1

                    },

                  new Album(){
                        album_title = "Recovery",
                        album_genre = "hip-hop",
                        release_date = new DateTime(2010, 6, 18),
                        ArtistId = 1

                    },
                };


                context.AddRange(AlbumList);
                context.SaveChanges();
                
             //  context.Albums.Add(albumE1);
             //  context.SaveChanges();
                
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