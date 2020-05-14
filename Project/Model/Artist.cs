using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Model
{
    public class Artist
    {
        public int Id { get; set; }

         /////MODEL VALIDATION/////////
        [Required]
        public string artistname { get; set; }
        [JsonIgnore]

        public ICollection<Album> Albums {get; set;}

        //artiest heeft meerdere band members
        public ICollection<ArtistTrack> ArtistTrack {get; set;}

        public ICollection<Track> Tracks {get;set;}

        
    }
}