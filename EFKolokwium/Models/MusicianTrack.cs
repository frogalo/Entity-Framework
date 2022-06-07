using System.Collections.Generic;

namespace EFKolokwium.Models
{
    public class MusicianTrack
    {
        public virtual Track Track { get; set; }
        public virtual Musician Musician { get; set; }
        public int IdTrack { get; set; }
        public int IdMusician { get; set; }
        public virtual ICollection<Musician> Musicians {get; set;}
        public virtual ICollection<Track> Tracks {get; set;}
    }
}