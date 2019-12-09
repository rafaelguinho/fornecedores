using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using mvc.Models;

namespace mvc.Context
{
    public class FornecedoresContext : DbContext
    {
        public DbSet<Empresa> Empresas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=fornecedores.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Empresa>().HasKey(e => e.Id);
        }
    }


}