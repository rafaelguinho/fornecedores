using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using mvc.Models;
using mvc.Models.Pessoas;

namespace mvc.Context
{
    public class FornecedoresContext : DbContext
    {
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<FornecedorPessoaFisica> FornecedoresPessoaFisica { get; set; }

        public DbSet<FornecedorPessoaJuridica> FornecedoresPessoaJuridica { get; set; }
        
        public DbSet<Pessoa> Pessoas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=fornecedores.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

             modelBuilder.Entity<Pessoa>()
            .HasDiscriminator<string>("TipoPessoa")
            .HasValue<PessoaFisica>("Física")
            .HasValue<PessoaJuridica>("Jurídica")
            .HasValue<Empresa>("Jurídica empresa")
            .HasValue<FornecedorPessoaJuridica>("Jurídica fornecedor")
            .HasValue<FornecedorPessoaFisica>("Física fornecedor");

            modelBuilder.Entity<Pessoa>().HasKey(e => e.Id);

            modelBuilder.Entity<Pessoa>()
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<FornecedorPessoaFisica>()
            .HasOne<Empresa>(s => s.Empresa)
            .WithMany(g => g.FornecedoresPessoaFisica)
            .HasForeignKey(s => s.IdEmpresa);

            modelBuilder.Entity<FornecedorPessoaJuridica>()
            .HasOne<Empresa>(s => s.Empresa)
            .WithMany(g => g.FornecedoresPessoaJuridica)
            .HasForeignKey(s => s.IdEmpresa);


            modelBuilder.Entity<Empresa>()
                .HasMany(c => c.FornecedoresPessoaFisica)
                .WithOne(e => e.Empresa);


                modelBuilder.Entity<Empresa>()
                .HasMany(c => c.FornecedoresPessoaJuridica)
                .WithOne(e => e.Empresa);

                modelBuilder.Entity<Pessoa>()
                .HasMany(c => c.Telefones)
                .WithOne(e => e.Pessoa);
        }
    }


}