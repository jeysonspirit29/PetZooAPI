namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Token")]
    public partial class Token
    {
        [Key]
        public long IdToken { get; set; }

        [Column("Token")]
        [Required]
        [StringLength(300)]
        public string Token1 { get; set; }

        public long IdUsuario { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
