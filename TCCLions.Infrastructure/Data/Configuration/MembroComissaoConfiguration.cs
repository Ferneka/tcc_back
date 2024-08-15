using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCCLions.Domain.Data.Models;

namespace TCCLions.Infrastructure.Data.Configuration
{
    public class MembroComissaoConfiguration : IEntityTypeConfiguration<MembroComissao>
    {
        public void Configure(EntityTypeBuilder<MembroComissao> modelBuilder){
            modelBuilder.ToTable("Membro e Comissao");

            modelBuilder.HasKey(prop => prop.Id);

            modelBuilder.Property(prop => prop.IdMembro)
            .IsRequired()
            .HasColumnName("IdMembro")
            .HasColumnType("text");
        
            modelBuilder.Property(prop => prop.IdComissao)
            .IsRequired()
            .HasColumnName("IdComissao")
            .HasColumnType("text");

            modelBuilder.Property(prop => prop.DataInicio)
            .IsRequired()
            .HasColumnName("DataInicio")
            .HasColumnType("date");

            modelBuilder.Property(prop => prop.DataFim)
            .IsRequired()
            .HasColumnName("DataFim")
            .HasColumnType("date");
        }
    }
}