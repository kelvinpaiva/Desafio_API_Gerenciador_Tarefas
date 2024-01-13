using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIGerenciador_Tarefas.Models
{
    public partial class wnbokcfxContext : DbContext
    {
        public wnbokcfxContext()
        {
        }

        public wnbokcfxContext(DbContextOptions<wnbokcfxContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LatLancamentoTarefa> LatLancamentoTarefas { get; set; } = null!;
        public virtual DbSet<LctLancamentoComentarioTarefa> LctLancamentoComentarioTarefas { get; set; } = null!;
        public virtual DbSet<ProProjeto> ProProjetos { get; set; } = null!;
        public virtual DbSet<TarTarefa> TarTarefas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("btree_gin")
                .HasPostgresExtension("btree_gist")
                .HasPostgresExtension("citext")
                .HasPostgresExtension("cube")
                .HasPostgresExtension("dblink")
                .HasPostgresExtension("dict_int")
                .HasPostgresExtension("dict_xsyn")
                .HasPostgresExtension("earthdistance")
                .HasPostgresExtension("fuzzystrmatch")
                .HasPostgresExtension("hstore")
                .HasPostgresExtension("intarray")
                .HasPostgresExtension("ltree")
                .HasPostgresExtension("pg_stat_statements")
                .HasPostgresExtension("pg_trgm")
                .HasPostgresExtension("pgcrypto")
                .HasPostgresExtension("pgrowlocks")
                .HasPostgresExtension("pgstattuple")
                .HasPostgresExtension("tablefunc")
                .HasPostgresExtension("unaccent")
                .HasPostgresExtension("uuid-ossp")
                .HasPostgresExtension("xml2");

            modelBuilder.Entity<LatLancamentoTarefa>(entity =>
            {
                entity.ToTable("lat_lancamento_tarefa");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdPro).HasColumnName("id_pro");

                entity.Property(e => e.IdTar).HasColumnName("id_tar");

                entity.HasOne(d => d.IdProNavigation)
                    .WithMany(p => p.LatLancamentoTarefas)
                    .HasForeignKey(d => d.IdPro)
                    .HasConstraintName("lat_lancamento_tarefa_fk");

                entity.HasOne(d => d.IdTarNavigation)
                    .WithMany(p => p.LatLancamentoTarefas)
                    .HasForeignKey(d => d.IdTar)
                    .HasConstraintName("lat_lancamento_tarefa_fk_1");
            });

            modelBuilder.Entity<LctLancamentoComentarioTarefa>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("lct_lancamento_comentario_tarefa");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.IdTar).HasColumnName("id_tar");

                entity.Property(e => e.LctComentario)
                    .HasMaxLength(255)
                    .HasColumnName("lct_comentario");
            });

            modelBuilder.Entity<ProProjeto>(entity =>
            {
                entity.ToTable("pro_projeto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProTitulo)
                    .HasMaxLength(255)
                    .HasColumnName("pro_titulo");
            });

            modelBuilder.Entity<TarTarefa>(entity =>
            {
                entity.ToTable("tar_tarefa");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TarDataValidade).HasColumnName("tar_data_validade");

                entity.Property(e => e.TarDescricao)
                    .HasMaxLength(255)
                    .HasColumnName("tar_descricao");

                entity.Property(e => e.TarPrioridade).HasColumnName("tar_prioridade");

                entity.Property(e => e.TarStatus).HasColumnName("tar_status");

                entity.Property(e => e.TarTitulo)
                    .HasMaxLength(100)
                    .HasColumnName("tar_titulo");

                entity.HasOne(d => d.Id_Projeto)
                   .WithMany(p => p.)
                   .HasForeignKey(d => d.)
                   .HasConstraintName("tar_tarefa_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
