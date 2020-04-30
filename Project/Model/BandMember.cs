using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Model
{
    public class BandMember
    {
        public int Id { get; set; }

        public string Instrument { get; set; }
        public string member_name { get; set; }
        [JsonIgnore]

        public Artist Artist { get; set; }
       
        
    }
}