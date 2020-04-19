using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Model
{
    public class Album
    {
        public int Id { get; set; }
        public int album_id { get; set; }
        public string album_title { get; set; }
        public string album_genre { get; set; }
        [JsonIgnore]

        //1 op veel relatie --> album heeft 1 artiest 
        public Artist Artist { get; set; }

        //album heeft meerder tracks
        
    }
}