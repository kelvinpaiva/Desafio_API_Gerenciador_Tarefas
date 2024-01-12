using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIGerenciador_Tarefas
{
    public partial class Gerenciador_TarefasContext : DbContext
    {
        public Gerenciador_TarefasContext()
        {
        }

        public Gerenciador_TarefasContext(DbContextOptions<Gerenciador_TarefasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LatLancamentoTarefa> LatLancamentoTarefas { get; set; } = null!;
        public virtual DbSet<ProProjeto> ProProjetos { get; set; } = null!;
        public virtual DbSet<TarTarefa> TarTarefas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=KELVIN-NOTEBOOK\\SQLEXPRESS;Initial Catalog=Gerenciador_Tarefas;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LatLancamentoTarefa>(entity =>
            {
                entity.ToTable("lat_lancamento_tarefa");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdPro)
                    .HasColumnName("id_pro")
                    .HasComment("Id do Projeto");

                entity.Property(e => e.IdTar)
                    .HasColumnName("id_tar")
                    .HasComment("Id da Tarefa");

                entity.HasOne(d => d.IdProNavigation)
                    .WithMany(p => p.LatLancamentoTarefas)
                    .HasForeignKey(d => d.IdPro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_lat_lancamento_tarefa_pro_projeto");

                entity.HasOne(d => d.IdTarNavigation)
                    .WithMany(p => p.LatLancamentoTarefas)
                    .HasForeignKey(d => d.IdTar)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_lat_lancamento_tarefa_tar_tarefas");
            });

            modelBuilder.Entity<ProProjeto>(entity =>
            {
                entity.ToTable("pro_projeto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProTitulo)
                    .HasMaxLength(100)
                    .HasColumnName("pro_titulo")
                    .IsFixedLength();
            });

            modelBuilder.Entity<TarTarefa>(entity =>
            {
                entity.ToTable("tar_tarefas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TarDataCadastro)
                    .HasColumnType("date")
                    .HasColumnName("tar_data_cadastro");

                entity.Property(e => e.TarDataVencimento)
                    .HasColumnType("date")
                    .HasColumnName("tar_data_vencimento");

                entity.Property(e => e.TarDescricao)
                    .HasMaxLength(255)
                    .HasColumnName("tar_descricao")
                    .IsFixedLength();

                entity.Property(e => e.TarPrioridade).HasColumnName("tar_prioridade");

                entity.Property(e => e.TarStatus).HasColumnName("tar_status");

                entity.Property(e => e.TarTitulo)
                    .HasMaxLength(100)
                    .HasColumnName("tar_titulo")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
