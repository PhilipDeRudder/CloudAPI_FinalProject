using System;
using System.Collections.Generic;

namespace Model
{
    public class Track
    {
        public int Id { get; set; }
        public string track_name { get; set; }
        public int track_time { get; set; }
        public string genre { get; set; }


        public ICollection<ArtistTrack> ArtistTrack {get; set;}

    }
}