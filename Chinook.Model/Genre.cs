using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chinook.Model
{   

    [Table("Genre")]
    public partial class Genre
    {
        public Genre()
        {
            Track = new HashSet<Track>();
        }

        public int GenreId { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(120)]
        public string Name { get; set; }

        public virtual ICollection<Track> Track { get; set; }
    }
}
