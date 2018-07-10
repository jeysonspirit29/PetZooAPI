namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Alerta")]
    public partial class Alerta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Alerta()
        {
            Foto = new HashSet<Foto>();
        }

        [Key]
        public long IdAlerta { get; set; }

        [Required]
        [StringLength(1024)]
        public string Descripcion { get; set; }

        public decimal Latitud { get; set; }

        public decimal Longitud { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime FechaAlerta { get; set; }

        public long IdPersona { get; set; }

        public long? IdPersonaRescate { get; set; }

        public int IdClaseMascota { get; set; }

        public int IdEstadoAlerta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Foto> Foto { get; set; }

        public virtual ClaseMascota ClaseMascota { get; set; }

        public virtual EstadoAlerta EstadoAlerta { get; set; }

        public virtual Persona Persona { get; set; }

        public virtual Persona Persona1 { get; set; }
    }
}
