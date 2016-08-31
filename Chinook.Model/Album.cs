using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Chinook.Model
{
    
    [Table("Album")]
    public partial class Album
    {
        
        public Album()
        {
            Track = new HashSet<Track>();
        }

        public int AlbumId { get; set; }

        [Required(ErrorMessage ="Este campo es requerido. ")]
        [StringLength(160, ErrorMessage ="Este campo requiere como maximo 160 caracteres. ")]
        public string Title { get; set; }


        public int ArtistId { get; set; }

        public virtual Artist Artist { get; set; }

        public virtual ICollection<Track> Track { get; set; }
    }
}
