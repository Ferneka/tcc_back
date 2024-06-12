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
            modelBuilder.HasKey(prop => prop.IdComissao);

            modelBuilder.Property(prop => prop.IdTipoComissao)
            .IsRequired()
            .HasColumnName("IdTipoComissao")
            .HasColumnType("varchar(40)");

            modelBuilder.Property(prop => prop.IdAdmin)
            .IsRequired()
            .HasColumnName("IdAdmim")
            .HasColumnType("varchar(40)");
        }
    }
}