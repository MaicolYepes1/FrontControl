using ApiControlAcceso.MODELS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiControlAcceso.INFRA.Context
{
    public partial class AppDataContext : DbContext
    {
        #region Constructors
        public AppDataContext()
        {
        }
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {
        }
        #endregion

        #region DbSets
        public virtual DbSet<LoginControl> LoginControls { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Genero> Generos { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }
        public virtual DbSet<Visitante> Visitantes { get; set; }
        public virtual DbSet<Arl> Arls { get; set; }
        public virtual DbSet<Equipo> Equipos { get; set; }
        public virtual DbSet<Incidente> Incidentes { get; set; }
        public virtual DbSet<VehiculosVisitante> VehiculosVisitantes { get; set; }
        public virtual DbSet<Helper> Helpers { get; set; }
        #endregion

        #region OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=AGILSOLUTIONS;Database=AS_Access;User Id=integrator;Password=Medellin1;");
            }
        }
        #endregion

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Arl>(entity =>
            {
                entity.Property(e => e.Detalle).HasMaxLength(200);

                entity.Property(e => e.Documento).HasMaxLength(20);

                entity.Property(e => e.FechaExpiracion).HasMaxLength(30);
            });

            modelBuilder.Entity<Equipo>(entity =>
            {
                entity.Property(e => e.Color).HasMaxLength(20);

                entity.Property(e => e.Detalle).HasMaxLength(200);

                entity.Property(e => e.Marca).HasMaxLength(40);

                entity.Property(e => e.Modelo).HasMaxLength(20);

                entity.Property(e => e.Serial).HasMaxLength(40);
            });

            modelBuilder.Entity<Incidente>(entity =>
            {
                entity.Property(e => e.Asunto)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VehiculosVisitante>(entity =>
            {
                entity.Property(e => e.Color).HasMaxLength(30);

                entity.Property(e => e.Detalle).HasMaxLength(200);

                entity.Property(e => e.Marca).HasMaxLength(50);

                entity.Property(e => e.Placa).HasMaxLength(20);
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.Property(e => e.Abr)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoDocumento>(entity =>
            {
                entity.Property(e => e.Abr)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Visitante>(entity =>
            {
                entity.Property(e => e.Apellidos)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoTarjeta)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Codigo_Tarjeta");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Detalle)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Empresa)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FExpedicionDoc)
                    .HasMaxLength(50)
                    .HasColumnName("F_Expedicion_Doc");

                entity.Property(e => e.Firma).IsUnicode(false);

                entity.Property(e => e.Foto).IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Profesion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpleadoResponsable)
                   .HasMaxLength(50)
                   .IsUnicode(false);

                entity.Property(e => e.Rh)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDoc).HasColumnName("Tipo_Doc")
                    .HasMaxLength(50)
                    .IsUnicode(false); ;

                entity.Property(e => e.TipoVisitante)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Tipo_Visitante");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnName("FechaIngreso")
                    .HasPrecision(0)
                    .HasColumnType("datetime2");

                entity.Property(e => e.FechaSalida)
                    .HasColumnName("FechaSalida")
                    .HasPrecision(0)
                    .HasColumnType("datetime2");
            });

            modelBuilder.Entity<LoginControl>(entity =>
            {
                entity.ToTable("LoginControl");

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Usser)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Foto)
                  .IsRequired()
                  .IsUnicode(false);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.Property(e => e.Page)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Helper>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }
        #endregion

        #region OnModelCreatingParital
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        #endregion
    }
}
