using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Model
{
    public class Artist
    {
        public int Id { get; set; }
        public string artist_name { get; set; }
        [JsonIgnore]

        public ICollection<Album> Albums {get; set;}

        //artiest heeft meerdere band members
        public ICollection<BandMember> BandMembers{get; set;}

       


       
        
    }
}