using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Model
{
    public class ArtistTrack
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
       
        public int ArtistId { get; set; }
        public int TrackId { get; set; }

     


    }
}