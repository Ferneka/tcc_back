using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCCLions.Domain.Data.Models;

namespace TCCLions.Infrastructure.Data.Configuration
{
    public class TipoDespesaConfiguration : IEntityTypeConfiguration<TipoDespesa>
    {
        public void Configure(EntityTypeBuilder<TipoDespesa> modelBuilder){
            modelBuilder.ToTable("TipoDespesa");

            modelBuilder.HasKey(prop => prop.Id);

            modelBuilder.Property(prop => prop.Descricao)
            .IsRequired()
            .HasColumnName("Descricao")
            .HasColumnType("varchar(50)");
        }
    }
}