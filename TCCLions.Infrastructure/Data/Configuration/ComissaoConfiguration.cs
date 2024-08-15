using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCCLions.Domain.Data.Models;

namespace TCCLions.Infrastructure.Data.Configuration
{
    public class ComissaoConfiguration : IEntityTypeConfiguration<Comissao>
    {
        public void Configure(EntityTypeBuilder<Comissao> modelBuilder){
            modelBuilder.ToTable("Comissao");

            modelBuilder.HasKey(prop => prop.Id);

            modelBuilder.Property(prop => prop.IdTipoComissao)
            .IsRequired()
            .HasColumnName("IdTipoComissao")
            .HasColumnType("text");

        }
    }
}