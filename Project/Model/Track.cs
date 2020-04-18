using System.Collections.Generic;

namespace Model
{
    public class Track
    {
        public int Id { get; set; }
        public int track_id { get; set; }
        public string track_name { get; set; }
        public int track_time { get; set; }
        public string genre { get; set; }

        // 1 op veel relatie met Album
        public Album Album { get; set; }

        //Veel op veel relatie met artist --> track kan meerdere aritesten hebben
        public ICollection<Artist> Artists { get; set; }

    }
}