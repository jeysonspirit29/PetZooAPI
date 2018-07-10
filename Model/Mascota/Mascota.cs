namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Mascota")]
    public partial class Mascota
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mascota()
        {
            Foto = new HashSet<Foto>();
            Publicacion = new HashSet<Publicacion>();
            Transferencia = new HashSet<Transferencia>();
            Comportamiento = new HashSet<Comportamiento>();
        }

        [Key]
        public long IdMascota { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaNacimiento { get; set; }

        public bool EsMacho { get; set; }

        public bool TieneMicroChip { get; set; }

        public bool EstaVacunado { get; set; }

        public bool EstaEsterilizado { get; set; }

        public int IdClaseMascota { get; set; }

        [StringLength(6)]
        public string IdColor { get; set; }

        public int? IdRaza { get; set; }

        public int IdEstadoMascota { get; set; }

        public int? IdTamano { get; set; }

        public virtual ClaseMascota ClaseMascota { get; set; }

        public virtual Color Color { get; set; }

        public virtual EstadoMascota EstadoMascota { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Foto> Foto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Publicacion> Publicacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transferencia> Transferencia { get; set; }

        public virtual Raza Raza { get; set; }

        public virtual Tamano Tamano { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comportamiento> Comportamiento { get; set; }
    }
}
