using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Calculadora.Domain.Entities;

namespace Calculadora.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Tasa> Tasas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tasa>(entity =>
            {
                entity.ToTable("tasa");
                entity.HasKey(e => e.id);
                entity.Property(e => e.pais_nombre).HasMaxLength(100).IsRequired();
                entity.Property(e => e.tarifa_usd).HasColumnType("decimal(10,2)").IsRequired();
                entity.Property(e => e.creado_en).HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuarios");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.usuario).HasMaxLength(50).IsRequired();
                entity.Property(e => e.password_hash).HasMaxLength(256).IsRequired();
                entity.Property(e => e.creado_en).HasDefaultValueSql("GETDATE()");
            });
        }
    }
}
