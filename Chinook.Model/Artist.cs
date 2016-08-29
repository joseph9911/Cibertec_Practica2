using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chinook.Model
{


    [Table("Artist")]
    public partial class Artist
    {
        public Artist()
        {
            Album = new HashSet<Album>();
        }

        public int ArtistId { get; set; }

        [StringLength(120)]
        public string Name { get; set; }
                
        public virtual ICollection<Album> Album { get; set; }
    }
}
