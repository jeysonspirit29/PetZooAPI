namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Foto")]
    public partial class Foto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long IdFoto { get; set; }

        [Required]
        [StringLength(350)]
        public string Path { get; set; }

        public long? IdMascota { get; set; }

        public long? IdUsuario { get; set; }

        public long? IdAlerta { get; set; }

        public virtual Alerta Alerta { get; set; }

        public virtual Mascota Mascota { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
