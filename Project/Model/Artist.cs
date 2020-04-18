using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Model
{
    public class Artist
    {
        public int Id { get; set; }
        public int artist_id { get; set; }
        public string artist_name { get; set; }
        [JsonIgnore]

        //artiest heeft meerdere albums --> 1 op veel
        public ICollection<Album> Albums { get; set; }
        // artiest heeft meerdere tracks --> Track kan meerdere artiesten hebben  veel op veel
        public ICollection<Track> Tracks { get; set; }
        
    }
}