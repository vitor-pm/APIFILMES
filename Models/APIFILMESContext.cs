using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIFILMES.Models
{
    public partial class APIFILMESContext : DbContext
    {
        public APIFILMESContext()
        {
        }

        public APIFILMESContext(DbContextOptions<APIFILMESContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAtor> TbAtors { get; set; } = null!;
        public virtual DbSet<TbDiretor> TbDiretors { get; set; } = null!;
        public virtual DbSet<TbFilme> TbFilmes { get; set; } = null!;
        public virtual DbSet<TbFilmeAtor> TbFilmeAtors { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;user id=root;password=1234;database=APIFILMES", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<TbAtor>(entity =>
            {
                entity.HasKey(e => e.IdAtor)
                    .HasName("PRIMARY");

                entity.Property(e => e.IdAtor).ValueGeneratedNever();
            });

            modelBuilder.Entity<TbDiretor>(entity =>
            {
                entity.HasKey(e => e.IdDiretor)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<TbFilme>(entity =>
            {
                entity.HasKey(e => e.IdFilme)
                    .HasName("PRIMARY");

                entity.HasOne(d => d.IdDiretorNavigation)
                    .WithMany(p => p.TbFilmes)
                    .HasForeignKey(d => d.IdDiretor)
                    .HasConstraintName("fk_tb_filme_tb_diretor");
            });

            modelBuilder.Entity<TbFilmeAtor>(entity =>
            {
                entity.HasKey(e => e.IdFilmeAtor)
                    .HasName("PRIMARY");

                entity.HasOne(d => d.IdAtorNavigation)
                    .WithMany(p => p.TbFilmeAtors)
                    .HasForeignKey(d => d.IdAtor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_filme_ator_tb_ator1");

                entity.HasOne(d => d.IdFilmeNavigation)
                    .WithMany(p => p.TbFilmeAtors)
                    .HasForeignKey(d => d.IdFilme)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_filme_ator_tb_filme1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
