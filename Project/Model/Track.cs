using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;


namespace Model
{
    public class Track
    {
        public int Id { get; set; }
        [Required]
        public string track_name { get; set; }
        [Required]
        public string genre { get; set; }
        [JsonIgnore]

        public ICollection<ArtistTrack> ArtistTrack {get; set;}

    }
}