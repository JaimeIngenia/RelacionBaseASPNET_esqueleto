using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DBRELACIONV2.Models
{
    public partial class DBRELACIONContext : DbContext
    {
        public DBRELACIONContext()
        {
        }

        public DBRELACIONContext(DbContextOptions<DBRELACIONContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar la relación uno a muchos
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("USUARIO");

                entity.HasKey(e => e.Id);

                // Configurar la relación con TipoDocumento
                entity.HasOne(e => e.IdTipoDocumentoNavigation)
                    .WithMany(t => t.Usuarios)
                    .HasForeignKey(e => e.IdTipoDocumento)
                    .HasConstraintName("FK_Usuario_TipoDocumento");

                // Resto de las configuraciones para la entidad Usuario
            });

            modelBuilder.Entity<TipoDocumento>(entity =>
            {
                entity.ToTable("TIPODOCUMENTO");

                entity.HasKey(e => e.Id);

                // Resto de las configuraciones para la entidad TipoDocumento
            });

       
        }



        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // Configurar la relación uno a muchos
        //    modelBuilder.Entity<Usuario>(entity =>
        //    {

        //        entity.ToTable("USUARIO");

        //    };

        //    modelBuilder.Entity<TipoDocumento>(entity =>
        //    {

        //        entity.ToTable("TIPODOCUMENTO");

        //    };

        //    OnModelCreatingPartial(modelBuilder);
        //}

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
