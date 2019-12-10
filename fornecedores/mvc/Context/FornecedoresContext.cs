using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using mvc.Models;

namespace mvc.Context
{
    public class FornecedoresContext : DbContext
    {
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=fornecedores.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Empresa>().HasKey(e => e.CNPJ);

            modelBuilder.Entity<Fornecedor>().HasKey(e => e.Id);

            modelBuilder.Entity<Fornecedor>()
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Fornecedor>()
            .HasOne<Empresa>(s => s.Empresa)
            .WithMany(g => g.Fornecedores)
            .HasForeignKey(s => s.CNPJEmpresa);


            modelBuilder.Entity<Empresa>()
                .HasMany(c => c.Fornecedores)
                .WithOne(e => e.Empresa);

                modelBuilder.Entity<Fornecedor>()
                .HasMany(c => c.Telefones)
                .WithOne(e => e.Fornecedor);
        }
    }


}