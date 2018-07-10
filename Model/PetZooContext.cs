namespace Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PetZooContext : DbContext
    {
        public PetZooContext()
            : base("name=PetZooContext")
        {
        }

        public virtual DbSet<Alerta> Alerta { get; set; }
        public virtual DbSet<ClaseMascota> ClaseMascota { get; set; }
        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<Comportamiento> Comportamiento { get; set; }
        public virtual DbSet<Distrito> Distrito { get; set; }
        public virtual DbSet<EstadoAlerta> EstadoAlerta { get; set; }
        public virtual DbSet<EstadoMascota> EstadoMascota { get; set; }
        public virtual DbSet<EstadoSolicitud> EstadoSolicitud { get; set; }
        public virtual DbSet<Foto> Foto { get; set; }
        public virtual DbSet<Mascota> Mascota { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Provincia> Provincia { get; set; }
        public virtual DbSet<Publicacion> Publicacion { get; set; }
        public virtual DbSet<Raza> Raza { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Solicitud> Solicitud { get; set; }
        public virtual DbSet<Tamano> Tamano { get; set; }
        public virtual DbSet<Token> Token { get; set; }
        public virtual DbSet<Transferencia> Transferencia { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alerta>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Alerta>()
                .Property(e => e.Latitud)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Alerta>()
                .Property(e => e.Longitud)
                .HasPrecision(18, 15);

            modelBuilder.Entity<ClaseMascota>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<ClaseMascota>()
                .HasMany(e => e.Alerta)
                .WithRequired(e => e.ClaseMascota)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ClaseMascota>()
                .HasMany(e => e.Mascota)
                .WithRequired(e => e.ClaseMascota)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Color>()
                .Property(e => e.IdColor)
                .IsUnicode(false);

            modelBuilder.Entity<Comportamiento>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Comportamiento>()
                .HasMany(e => e.Mascota)
                .WithMany(e => e.Comportamiento)
                .Map(m => m.ToTable("MascotaComportamiento").MapLeftKey("IdComportamiento").MapRightKey("IdMascota"));

            modelBuilder.Entity<Distrito>()
                .Property(e => e.IdDistrito)
                .IsUnicode(false);

            modelBuilder.Entity<Distrito>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Distrito>()
                .Property(e => e.IdProvincia)
                .IsUnicode(false);

            modelBuilder.Entity<Distrito>()
                .HasMany(e => e.Persona)
                .WithRequired(e => e.Distrito)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EstadoAlerta>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<EstadoAlerta>()
                .HasMany(e => e.Alerta)
                .WithRequired(e => e.EstadoAlerta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EstadoMascota>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<EstadoMascota>()
                .HasMany(e => e.Mascota)
                .WithRequired(e => e.EstadoMascota)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EstadoMascota>()
                .HasMany(e => e.Transferencia)
                .WithRequired(e => e.EstadoMascota)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EstadoSolicitud>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<EstadoSolicitud>()
                .HasMany(e => e.Solicitud)
                .WithRequired(e => e.EstadoSolicitud)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Foto>()
                .Property(e => e.Path)
                .IsUnicode(false);

            modelBuilder.Entity<Mascota>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Mascota>()
                .Property(e => e.IdColor)
                .IsUnicode(false);

            modelBuilder.Entity<Mascota>()
                .HasMany(e => e.Publicacion)
                .WithRequired(e => e.Mascota)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Mascota>()
                .HasMany(e => e.Transferencia)
                .WithRequired(e => e.Mascota)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.ApellidoPaterno)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.ApellidoMaterno)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.Celular)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.CorreoElectronico)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.Web)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.TipoPersona)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.Presentacion)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.IdDistrito)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .HasMany(e => e.Alerta)
                .WithRequired(e => e.Persona)
                .HasForeignKey(e => e.IdPersona)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Persona>()
                .HasMany(e => e.Alerta1)
                .WithOptional(e => e.Persona1)
                .HasForeignKey(e => e.IdPersonaRescate);

            modelBuilder.Entity<Persona>()
                .HasMany(e => e.Solicitud)
                .WithRequired(e => e.Persona)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Persona>()
                .HasMany(e => e.Transferencia)
                .WithRequired(e => e.Persona)
                .HasForeignKey(e => e.IdPersonaOrigen)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Persona>()
                .HasMany(e => e.Transferencia1)
                .WithRequired(e => e.Persona1)
                .HasForeignKey(e => e.IdPersonaDestino)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Persona>()
                .HasMany(e => e.Usuario)
                .WithRequired(e => e.Persona)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Provincia>()
                .Property(e => e.IdProvincia)
                .IsUnicode(false);

            modelBuilder.Entity<Provincia>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Provincia>()
                .Property(e => e.IdRegion)
                .IsUnicode(false);

            modelBuilder.Entity<Provincia>()
                .HasMany(e => e.Distrito)
                .WithRequired(e => e.Provincia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Publicacion>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Publicacion>()
                .HasMany(e => e.Solicitud)
                .WithRequired(e => e.Publicacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Raza>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Region>()
                .Property(e => e.IdRegion)
                .IsUnicode(false);

            modelBuilder.Entity<Region>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Region>()
                .HasMany(e => e.Provincia)
                .WithRequired(e => e.Region)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Solicitud>()
                .Property(e => e.Celular)
                .IsUnicode(false);

            modelBuilder.Entity<Solicitud>()
                .Property(e => e.CorreoElectronico)
                .IsUnicode(false);

            modelBuilder.Entity<Solicitud>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Solicitud>()
                .HasMany(e => e.Transferencia)
                .WithRequired(e => e.Solicitud)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tamano>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Token>()
                .Property(e => e.Token1)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Token)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);
        }
    }
}
