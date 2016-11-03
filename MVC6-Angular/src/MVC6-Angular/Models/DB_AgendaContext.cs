using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Angle_MVC6_Angular_Seed.Models
{
    public partial class DB_AgendaContext : DbContext
    {
        public virtual DbSet<Agenda> Agenda { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<TbAgenda> TbAgenda { get; set; }
        public virtual DbSet<TbTelefone> TbTelefone { get; set; }
        public virtual DbSet<TbTipoTelefone> TbTipoTelefone { get; set; }
        public virtual DbSet<Telefones> Telefones { get; set; }
        public virtual DbSet<TipoTelefones> TipoTelefones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=54.236.71.123;Database=DB_Agenda;User ID=agenda;Password=agenda;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agenda>(entity =>
            {
                entity.HasKey(e => e.CdAgenda)
                    .HasName("PK_dbo.Agenda");

                entity.Property(e => e.CdAgenda).HasColumnName("cdAgenda");

                entity.Property(e => e.DtAlteracao)
                    .HasColumnName("dtAlteracao")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtInclusao)
                    .HasColumnName("dtInclusao")
                    .HasColumnType("datetime");

                entity.Property(e => e.NmAgenda).HasColumnName("nmAgenda");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<TbAgenda>(entity =>
            {
                entity.HasKey(e => e.CdAgenda)
                    .HasName("PK_dbo.TB_Agenda");

                entity.ToTable("TB_Agenda");

                entity.Property(e => e.CdAgenda).HasColumnName("cdAgenda");

                entity.Property(e => e.DtAlteracao)
                    .HasColumnName("dtAlteracao")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtInclusao)
                    .HasColumnName("dtInclusao")
                    .HasColumnType("datetime");

                entity.Property(e => e.NmAgenda).HasColumnName("nmAgenda");
            });

            modelBuilder.Entity<TbTelefone>(entity =>
            {
                entity.HasKey(e => e.CdTelefone)
                    .HasName("PK_dbo.TB_Telefone");

                entity.ToTable("TB_Telefone");

                entity.HasIndex(e => e.CdAgenda)
                    .HasName("IX_cdAgenda");

                entity.HasIndex(e => e.CdTipoTelefone)
                    .HasName("IX_cdTipoTelefone");

                entity.Property(e => e.CdTelefone).HasColumnName("cdTelefone");

                entity.Property(e => e.CdAgenda).HasColumnName("cdAgenda");

                entity.Property(e => e.CdTipoTelefone).HasColumnName("cdTipoTelefone");

                entity.Property(e => e.DddTelefone)
                    .HasColumnName("dddTelefone")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DtAlteracao)
                    .HasColumnName("dtAlteracao")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtInclusao)
                    .HasColumnName("dtInclusao")
                    .HasColumnType("datetime");

                entity.Property(e => e.NmContato).HasColumnName("nmContato");

                entity.Property(e => e.NrTelefone).HasColumnName("nrTelefone");

                entity.HasOne(d => d.CdAgendaNavigation)
                    .WithMany(p => p.TbTelefone)
                    .HasForeignKey(d => d.CdAgenda)
                    .HasConstraintName("FK_dbo.TB_Telefone_dbo.TB_Agenda_cdAgenda");

                entity.HasOne(d => d.CdTipoTelefoneNavigation)
                    .WithMany(p => p.TbTelefone)
                    .HasForeignKey(d => d.CdTipoTelefone)
                    .HasConstraintName("FK_dbo.TB_Telefone_dbo.TB_TipoTelefone_cdTipoTelefone");
            });

            modelBuilder.Entity<TbTipoTelefone>(entity =>
            {
                entity.HasKey(e => e.CdTipoTelefone)
                    .HasName("PK_dbo.TB_TipoTelefone");

                entity.ToTable("TB_TipoTelefone");

                entity.Property(e => e.CdTipoTelefone).HasColumnName("cdTipoTelefone");

                entity.Property(e => e.DtAlteracao)
                    .HasColumnName("dtAlteracao")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtInclusao)
                    .HasColumnName("dtInclusao")
                    .HasColumnType("datetime");

                entity.Property(e => e.NmTipoTelefone).HasColumnName("nmTipoTelefone");
            });

            modelBuilder.Entity<Telefones>(entity =>
            {
                entity.HasKey(e => e.CdTelefone)
                    .HasName("PK_dbo.Telefones");

                entity.HasIndex(e => e.CdAgenda)
                    .HasName("IX_cdAgenda");

                entity.HasIndex(e => e.CdTipoTelefone)
                    .HasName("IX_cdTipoTelefone");

                entity.Property(e => e.CdTelefone).HasColumnName("cdTelefone");

                entity.Property(e => e.CdAgenda).HasColumnName("cdAgenda");

                entity.Property(e => e.CdTipoTelefone).HasColumnName("cdTipoTelefone");

                entity.Property(e => e.DddTelefone).HasColumnName("dddTelefone");

                entity.Property(e => e.DtAlteracao)
                    .HasColumnName("dtAlteracao")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtInclusao)
                    .HasColumnName("dtInclusao")
                    .HasColumnType("datetime");

                entity.Property(e => e.NmContato).HasColumnName("nmContato");

                entity.Property(e => e.NrTelefone).HasColumnName("nrTelefone");

                entity.HasOne(d => d.CdAgendaNavigation)
                    .WithMany(p => p.Telefones)
                    .HasForeignKey(d => d.CdAgenda)
                    .HasConstraintName("FK_dbo.Telefones_dbo.Agenda_cdAgenda");

                entity.HasOne(d => d.CdTipoTelefoneNavigation)
                    .WithMany(p => p.Telefones)
                    .HasForeignKey(d => d.CdTipoTelefone)
                    .HasConstraintName("FK_dbo.Telefones_dbo.TipoTelefones_cdTipoTelefone");
            });

            modelBuilder.Entity<TipoTelefones>(entity =>
            {
                entity.HasKey(e => e.CdTipoTelefone)
                    .HasName("PK_dbo.TipoTelefones");

                entity.Property(e => e.CdTipoTelefone).HasColumnName("cdTipoTelefone");

                entity.Property(e => e.DtAlteracao)
                    .HasColumnName("dtAlteracao")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtInclusao)
                    .HasColumnName("dtInclusao")
                    .HasColumnType("datetime");

                entity.Property(e => e.NmTipoTelefone).HasColumnName("nmTipoTelefone");
            });
        }
    }
}