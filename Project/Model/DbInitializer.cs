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
              
                ICollection<Artist> ArtistList = new List<Artist>()
                {
                  new Artist(){
                      artistname = "Eminem"

                    },
                  new Artist(){
                      artistname = "Ed Sheeran"
                  }


                };

                //toevoegen van testartiest aan databank
                context.Artists.AddRange(ArtistList);
                //opslagen van de aanpassingen aan de db
                context.SaveChanges();
            }
            
            //indien er nog geen albums aanwezig zijn...
            if (!context.Albums.Any())
            {
              

                ICollection<Album> AlbumList = new List<Album>(){
                    new Album(){
                    Title = "Infinite",
                    Genre = "hip-hop",
                  //  release_date = new DateTime(1996,11,12),
                    ArtistId = 1
                    },

                    new Album(){
                        Title = "Slim Shady EP",
                        Genre = "hip-hop",
                    //    release_date = new DateTime(1997, 12, 16),
                        ArtistId = 1

                    },

                     new Album(){
                        Title = "The Slim Shady LP",
                        Genre = "hip-hop",
                      //  release_date = new DateTime(1999, 2, 22),
                        ArtistId = 1

                    },
                    //datums

                     new Album(){
                        Title = "The Marshal Mathers LP",
                        Genre = "hip-hop",
                      //  release_date = new DateTime(2000, 5, 23),
                        ArtistId = 1

                    },

                      new Album(){
                        Title = "The Marshal Mathers LP-Tour edition",
                        Genre = "hip-hop",
                       // release_date = new DateTime(2002, 1, 1),
                        ArtistId = 1

                    },
                    
                      new Album(){
                        Title = "The Eminem Show",
                        Genre = "hip-hop",
                       // release_date = new DateTime(2002, 5, 26),
                        ArtistId = 1

                    },

                    new Album(){
                        Title = "The Singles",
                        Genre = "hip-hop",
                       // release_date = new DateTime(2003, 12, 23),
                        ArtistId = 1

                    },

                  new Album(){
                        Title = "Encore",
                        Genre = "hip-hop",
                       // release_date = new DateTime(2004, 11, 12),
                        ArtistId = 1

                    },
                  new Album(){
                        Title = "Curtain Call",
                        Genre = "hip-hop",
                       // release_date = new DateTime(2005, 12, 6),
                        ArtistId = 1

                    },

                  new Album(){
                        Title = "Relapse",
                        Genre = "hip-hop",
                       // release_date = new DateTime(2009, 5, 15),
                        ArtistId = 1

                    },

                  new Album(){
                        Title = "Recovery",
                        Genre = "hip-hop",
                       // release_date = new DateTime(2010, 6, 18),
                        ArtistId = 1

                    },

                  new Album(){
                      Title = "The Orange Room - EP",
                      Genre="pop",
                     // release_date = new DateTime(2005, 3, 12),
                      ArtistId = 2
                  },

                   new Album(){
                      Title = "Ed Sheeran - EP",
                      Genre="pop",
                    //  release_date = new DateTime(2006, 3, 22),
                      ArtistId = 2
                  },

                   new Album(){
                      Title = "Want Some? - EP",
                      Genre="pop",
                     // release_date = new DateTime(2007, 5, 1),
                      ArtistId = 2
                  },

                   new Album(){
                      Title = "You Need Me",
                      Genre="pop",
                    //  release_date = new DateTime(2009, 4,22),
                      ArtistId = 2
                  },

                   new Album(){
                      Title = "Loose change - EP",
                      Genre="pop",
                    //  release_date = new DateTime(2010, 7, 2),
                      ArtistId = 2
                  },

                   new Album(){
                      Title = "Song I Wrote With Amy - EP",
                      Genre="pop",
                     // release_date = new DateTime(2010, 4, 4),
                      ArtistId = 2
                  },

                   new Album(){
                      Title = "Live at the Bedford",
                      Genre="pop",
                    //  release_date = new DateTime(2011, 12, 12),
                      ArtistId = 2
                  },

                   new Album(){
                      Title = "Thank you",
                      Genre="pop",
                     // release_date = new DateTime(2011, 8, 18),
                      ArtistId = 2
                  },

                   new Album(){
                      Title = "You Need Me, I Don't Need You",
                      Genre="pop",
                     // release_date = new DateTime(2011, 8, 26),
                      ArtistId = 2
                  },

                   new Album(){
                      Title = "One Take - EP",
                      Genre="pop",
                     // release_date = new DateTime(2011, 4 ,7),
                      ArtistId = 2
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