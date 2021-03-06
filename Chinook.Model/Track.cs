using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chinook.Model
{

    [Table("Track")]
    public partial class Track
    {
        public Track()
        {
            InvoiceLine = new HashSet<InvoiceLine>();
            Playlist = new HashSet<Playlist>();
        }

        public int TrackId { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(200)]
        public string Name { get; set; }

        public int? AlbumId { get; set; }

        public int MediaTypeId { get; set; }

        public int? GenreId { get; set; }

        [StringLength(220)]
        public string Composer { get; set; }

        public int Milliseconds { get; set; }

        public int? Bytes { get; set; }

        [Column(TypeName = "numeric")]
        public decimal UnitPrice { get; set; }

        public virtual Album Album { get; set; }

        public virtual Genre Genre { get; set; }

        public virtual ICollection<InvoiceLine> InvoiceLine { get; set; }

        public virtual MediaType MediaType { get; set; }

        public virtual ICollection<Playlist> Playlist { get; set; }
    }
}
