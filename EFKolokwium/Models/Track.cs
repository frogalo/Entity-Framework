using System.Collections.Generic;

namespace EFKolokwium.Models
{
    public class Track
    {
        public int IdTrack { get; set; }
        public string TrackName { get; set; }
        public float Duration { get; set; }
        public virtual Album Album { get; set; }
        public int IdAlbum { get; set; }
        public virtual ICollection<Album> Albums {get; set;}
        public virtual ICollection<MusicianTrack> MusicianTracks {get; set;}

    }
}