using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCCLions.Domain.Data.Models;

namespace TCCLions.Infrastructure.Data.Configuration
{
    public class DespesaConfiguration : IEntityTypeConfiguration<Despesa>
    {
        public void Configure(EntityTypeBuilder<Despesa> modelBuilder){
            modelBuilder.ToTable("Despesa");
            
            modelBuilder.HasKey(prop => prop.Id);

            modelBuilder.Property(prop => prop.DataVencimento)
            .IsRequired()
            .HasColumnName("DataVencimento")
            .HasColumnType("date");

            modelBuilder.Property(prop => prop.DataRegistro)
            .IsRequired()
            .HasColumnName("DataRegistro")
            .HasColumnType("date");

            modelBuilder.Property(prop => prop.ValorTotal)
            .IsRequired()
            .HasColumnName("ValorTotal")
            .HasColumnType("decimal(8,2)");

            modelBuilder.Property(prop => prop.IdMembro)
            .IsRequired()
            .HasColumnName("IdMembro")
            .HasColumnType("text");

    
        
        }
    }
}