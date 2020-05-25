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
        [Required(ErrorMessage = "title is required")]
        public string Title { get; set; }
         [Required(ErrorMessage= "Genre is Required")]
         [StringLength(20 , ErrorMessage = "Maxum length of 20 char")]
        public string Genre { get; set; } 

        [Range(1, int.MaxValue)]
        public int ArtistId{get;set;}
        
        public DateTime release_date {get;set;}
         [JsonIgnore]
         public Artist Artist { get; set; }

     


    }
}