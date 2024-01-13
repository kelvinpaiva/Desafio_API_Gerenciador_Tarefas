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

        public virtual DbSet<LctLancamentoComentarioTarefa> LctLancamentoComentarioTarefas { get; set; } = null!;
        public virtual DbSet<LoaLogAplicacao> LoaLogAplicacaos { get; set; } = null!;
        public virtual DbSet<ProProjeto> ProProjetos { get; set; } = null!;
        public virtual DbSet<TarTarefa> TarTarefas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=motty.db.elephantsql.com;Database=wnbokcfx;Username=wnbokcfx;Password=Bwxfy0ehZH3sPNKYvW01vyslU4ZniZCd");
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

            modelBuilder.Entity<LctLancamentoComentarioTarefa>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("lct_lancamento_comentario_tarefa");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.IdTar).HasColumnName("id_tar");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.LctComentario)
                    .HasMaxLength(255)
                    .HasColumnName("lct_comentario");
            });

            modelBuilder.Entity<LoaLogAplicacao>(entity =>
            {
                entity.ToTable("loa_log_aplicacao");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdRegistro).HasColumnName("id_registro");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.LoaDescricaoLog).HasColumnName("loa_descricao_log");

                entity.Property(e => e.LoaTipoLog)
                    .HasColumnName("loa_tipo_log")
                    .HasComment("1 - Projeto, 2 - Tarefa, 3 - Comentario");
            });

            modelBuilder.Entity<ProProjeto>(entity =>
            {
                entity.ToTable("pro_projeto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.ProTitulo)
                    .HasMaxLength(255)
                    .HasColumnName("pro_titulo");
            });

            modelBuilder.Entity<TarTarefa>(entity =>
            {
                entity.ToTable("tar_tarefa");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdPro).HasColumnName("id_pro");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.TarDataValidade).HasColumnName("tar_data_validade");

                entity.Property(e => e.TarDescricao)
                    .HasMaxLength(255)
                    .HasColumnName("tar_descricao");

                entity.Property(e => e.TarPrioridade).HasColumnName("tar_prioridade");

                entity.Property(e => e.TarStatus).HasColumnName("tar_status");

                entity.Property(e => e.TarTitulo)
                    .HasMaxLength(100)
                    .HasColumnName("tar_titulo");

                entity.HasOne(d => d.IdProNavigation)
                    .WithMany(p => p.TarTarefas)
                    .HasForeignKey(d => d.IdPro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tar_tarefa_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
