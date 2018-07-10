namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Transferencia")]
    public partial class Transferencia
    {
        [Key]
        public long IdTransferencia { get; set; }

        public long IdPersonaOrigen { get; set; }

        public long IdPersonaDestino { get; set; }

        public long IdMascota { get; set; }

        public int IdEstadoMascota { get; set; }

        public long IdSolicitud { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime FechaRegistro { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaTransferencia { get; set; }

        public virtual EstadoMascota EstadoMascota { get; set; }

        public virtual Mascota Mascota { get; set; }

        public virtual Persona Persona { get; set; }

        public virtual Persona Persona1 { get; set; }

        public virtual Solicitud Solicitud { get; set; }
    }
}
