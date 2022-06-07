using System.Collections.Generic;

namespace EFKolokwium.Models
{
    public class MusicLabel
    {
        public int IdMusicLabel { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Album> Albums {get; set;}
    }
}