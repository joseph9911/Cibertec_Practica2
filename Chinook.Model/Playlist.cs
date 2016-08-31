using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chinook.Model
{

    [Table("Playlist")]
    public partial class Playlist
    {
        public Playlist()
        {
            Track = new HashSet<Track>();
        }

        public int PlaylistId { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(120)]
        public string Name { get; set; }

        public virtual ICollection<Track> Track { get; set; }
    }
}
