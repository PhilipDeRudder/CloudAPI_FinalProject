using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Model
{
    public class Track
    {
        public int Id { get; set; }
        public string track_name { get; set; }
        public string genre { get; set; }
        [JsonIgnore]

        public ICollection<ArtistTrack> ArtistTrack {get; set;}

    }
}