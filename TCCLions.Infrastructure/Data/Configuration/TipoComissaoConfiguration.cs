using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCCLions.Domain.Data.Models;

namespace TCCLions.Infrastructure.Data.Configuration
{
    public class TipoComissaoConfiguration : IEntityTypeConfiguration<TipoComissao>
    {
        public void Configure(EntityTypeBuilder<TipoComissao> modelBuilder){
            modelBuilder.ToTable("TipoComissao");

            modelBuilder.HasKey(prop => prop.Id);

            modelBuilder.Property(prop => prop.Descricao)
            .IsRequired()
            .HasColumnName("Descricao")
            .HasColumnType("varchar(50)");
        }
    }
}