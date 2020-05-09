using System;
using System.Reflection.PortableExecutable;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Album
    {
        public int AlbumId { get; set; }

        /////MODEL VALIDATION/////////
        [Required]
        [StringLength(160, MinimumLength = 2)]
        public string album_title { get; set; }
        public string album_genre { get; set; } 
        public int ArtistId{get;set;}
        
        public DateTime release_date {get;set;}
         [JsonIgnore]

         public Artist Artist { get; set; }

     


    }
}