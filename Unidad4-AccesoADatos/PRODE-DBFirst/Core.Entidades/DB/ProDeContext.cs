using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Core.Entidades.DB
{
    public partial class ProDeContext : DbContext
    {
        public ProDeContext()
        {
        }

        public ProDeContext(DbContextOptions<ProDeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Apuesta> Apuesta { get; set; }
        public virtual DbSet<Equipo> Equipo { get; set; }
        public virtual DbSet<EquipoInfo> EquipoInfo { get; set; }
        public virtual DbSet<Evento> Evento { get; set; }
        public virtual DbSet<EventoTipo> EventoTipo { get; set; }
        public virtual DbSet<Fase> Fase { get; set; }
        public virtual DbSet<Partido> Partido { get; set; }
        public virtual DbSet<Temporada> Temporada { get; set; }
        public virtual DbSet<Torneo> Torneo { get; set; }
		public virtual DbSet<PartidoCompleto> PartidoCompleto { get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=ProDe;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apuesta>(entity =>
            {
                entity.ToTable("Apuesta", "apuesta");

                entity.Property(e => e.ApuestaId).ValueGeneratedNever();

                entity.HasOne(d => d.Partido)
                    .WithMany(p => p.Apuesta)
                    .HasForeignKey(d => d.PartidoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Apuesta_Partido");
            });

            modelBuilder.Entity<Equipo>(entity =>
            {
                entity.ToTable("Equipo", "equipo");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EquipoInfo>(entity =>
            {
                entity.HasKey(e => e.EquipoId);

                entity.ToTable("EquipoInfo", "equipo");

                entity.Property(e => e.EquipoId).ValueGeneratedNever();

                entity.Property(e => e.IconoUrl)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Instagram)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Twitter)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Web)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Equipo)
                    .WithOne(p => p.EquipoInfo)
                    .HasForeignKey<EquipoInfo>(d => d.EquipoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_EquipoInfo_Equipo");
            });

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.ToTable("Evento", "partido");

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.HasOne(d => d.Equipo)
                    .WithMany(p => p.Evento)
                    .HasForeignKey(d => d.EquipoId)
                    .HasConstraintName("FK_Evento_Equipo");

                entity.HasOne(d => d.EventoTipo)
                    .WithMany(p => p.Evento)
                    .HasForeignKey(d => d.EventoTipoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Evento_EventoTipo");

                entity.HasOne(d => d.Partido)
                    .WithMany(p => p.Evento)
                    .HasForeignKey(d => d.PartidoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Evento_Partido");
            });

            modelBuilder.Entity<EventoTipo>(entity =>
            {
                entity.ToTable("EventoTipo", "partido");

                entity.Property(e => e.EventoTipoId).ValueGeneratedNever();

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Fase>(entity =>
            {
                entity.ToTable("Fase", "torneo");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Torneo)
                    .WithMany(p => p.Fase)
                    .HasForeignKey(d => d.TorneoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fase_Torneo");
            });

            modelBuilder.Entity<Partido>(entity =>
            {
                entity.ToTable("Partido", "partido");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.HasOne(d => d.EquipoIdLocalNavigation)
                    .WithMany(p => p.PartidoEquipoIdLocalNavigation)
                    .HasForeignKey(d => d.EquipoIdLocal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Partido_Equipo_Local");

                entity.HasOne(d => d.EquipoIdVisitanteNavigation)
                    .WithMany(p => p.PartidoEquipoIdVisitanteNavigation)
                    .HasForeignKey(d => d.EquipoIdVisitante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Partido_Equipo_Visitante");

                entity.HasOne(d => d.Fase)
                    .WithMany(p => p.Partido)
                    .HasForeignKey(d => d.FaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Partido_Fase");
            });

            modelBuilder.Entity<Temporada>(entity =>
            {
                entity.ToTable("Temporada", "torneo");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Torneo>(entity =>
            {
                entity.ToTable("Torneo", "torneo");

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.Temporada)
                    .WithMany(p => p.Torneo)
                    .HasForeignKey(d => d.TemporadaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Torneo_Temporada");
            });
        }
    }
}
