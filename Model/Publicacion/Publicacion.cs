namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Publicacion")]
    public partial class Publicacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Publicacion()
        {
            Solicitud = new HashSet<Solicitud>();
        }

        [Key]
        public long IdPublicacion { get; set; }

        public long NumeroMeGusta { get; set; }

        [StringLength(1024)]
        public string Descripcion { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime FechaPublicacion { get; set; }

        public long IdMascota { get; set; }

        public virtual Mascota Mascota { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Solicitud> Solicitud { get; set; }
    }
}
