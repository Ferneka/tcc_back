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
            modelBuilder.ApplyConfiguration(new AdministradorConfiguration());
            modelBuilder.ApplyConfiguration(new AtaConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Administrador> Administrador {get; set;}
    }
}