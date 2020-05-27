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
        [StringLength(27 , ErrorMessage = "Maxum length of 27 char")]
        public string Genre { get; set; } 

        [Range(1, 100)]
        public int ArtistId{get;set;}
        [Range(typeof(DateTime), "1/1/1860", "27/05/2020")]
        public DateTime release_date {get;set;}
         [JsonIgnore]
         public Artist Artist { get; set; }

     


    }
}