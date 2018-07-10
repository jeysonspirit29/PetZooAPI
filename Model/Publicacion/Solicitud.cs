namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Solicitud")]
    public partial class Solicitud
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Solicitud()
        {
            Transferencia = new HashSet<Transferencia>();
        }

        [Key]
        public long IdSolicitud { get; set; }

        [StringLength(20)]
        public string Celular { get; set; }

        [StringLength(100)]
        public string CorreoElectronico { get; set; }

        [Required]
        [StringLength(1024)]
        public string Descripcion { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime FechaSolicitud { get; set; }

        public long IdPersona { get; set; }

        public int IdEstadoSolicitud { get; set; }

        public long IdPublicacion { get; set; }

        public virtual EstadoSolicitud EstadoSolicitud { get; set; }

        public virtual Persona Persona { get; set; }

        public virtual Publicacion Publicacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transferencia> Transferencia { get; set; }
    }
}
