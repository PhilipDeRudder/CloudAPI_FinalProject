using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Model
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string album_title { get; set; }
        public string album_genre { get; set; } 

         public Artist Artist { get; set; }

     


    }
}