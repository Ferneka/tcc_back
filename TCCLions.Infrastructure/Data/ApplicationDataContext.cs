using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TCCLions.Domain.Data;
using TCCLions.Domain.Data.Models;
using TCCLions.Infrastructure.Data.Configuration;

namespace TCCLions.Infrastructure.Data
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options):base(options){

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AtaConfiguration());
            modelBuilder.ApplyConfiguration(new ComissaoConfiguration());
            modelBuilder.ApplyConfiguration(new DespesaConfiguration());
            modelBuilder.ApplyConfiguration(new DespesaTipoDespesaConfiguration());
            modelBuilder.ApplyConfiguration(new MembroComissaoConfiguration());
            modelBuilder.ApplyConfiguration(new MembroConfiguration());
            modelBuilder.ApplyConfiguration(new TipoComissaoConfiguration());
            modelBuilder.ApplyConfiguration(new TipoDespesaConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Ata> Ata {get; set;}
        public DbSet<Comissao> Comissao {get; set;}
        public DbSet<Despesa> Despesa {get; set;}
        public DbSet<DespesaTipoDespesa> DespesaTipoDespesa {get; set;}
        public DbSet<MembroComissao> MembroComissao {get; set;}
        public DbSet<Membro> Membro {get; set;}
        public DbSet<TipoComissao> TipoComissao {get; set;}
        public DbSet<TipoDespesa> TipoDespesa {get; set;}
    }
}