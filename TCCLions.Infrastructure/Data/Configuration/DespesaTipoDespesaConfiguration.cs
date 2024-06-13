using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCCLions.Domain.Data.Models;

namespace TCCLions.Infrastructure.Data.Configuration
{
    public class DespesaTipoDespesaConfiguration : IEntityTypeConfiguration<DespesaTipoDespesa>
    {
        public void Configure(EntityTypeBuilder<DespesaTipoDespesa> modelBuilder){
            modelBuilder.ToTable("Despesa e Tipo Despesa");

            modelBuilder.HasKey(prop => prop.IdDespesaTipoDespesa);

            modelBuilder.Property(prop => prop.IdDespesa)
            .IsRequired()
            .HasColumnName("IdDespesa")
            .HasColumnType("text");

            modelBuilder.Property(prop => prop.IdTipoDespesa)
            .IsRequired()
            .HasColumnName("IdTipoDespesa")
            .HasColumnType("text");

            modelBuilder.Property(prop => prop.Valor)
            .IsRequired()
            .HasColumnName("ValorDespesa")
            .HasColumnType("money");
        }
    }
}