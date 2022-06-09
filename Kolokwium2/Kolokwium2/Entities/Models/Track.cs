using System.Collections.Generic;

namespace Kolokwium2.Entities.Models
{
    public class Track
    {
        public int IdTrack { get; set; }
        public string TrackName { get; set; }
        public double Duration { get; set; }
        public int? IdMusicAlbum { get; set; }

        public virtual ICollection<MusicanTrack> MusicanTracks { get; set; }
        public virtual Album Album { get; set; }
    }
}