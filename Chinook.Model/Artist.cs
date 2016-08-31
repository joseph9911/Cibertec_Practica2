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


        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(120, ErrorMessage = "Este campo requiere como maximo 120 caracteres. ")]
        public string Name { get; set; }
                
        public virtual ICollection<Album> Album { get; set; }
    }
}
