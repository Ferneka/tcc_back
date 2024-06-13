using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCCLions.Domain.Data.Models;

namespace TCCLions.Infrastructure.Data.Configuration
{
    public class AtaConfiguration : IEntityTypeConfiguration<Ata>
    {
        public void Configure(EntityTypeBuilder<Ata> modelBuilder){
            modelBuilder.ToTable("Ata");

            modelBuilder.HasKey(prop => prop.Id);

            modelBuilder.Property(prop => prop.Titulo)
            .IsRequired()
            .HasColumnName("AtaTitulo")
            .HasColumnType("varchar(100)");

            modelBuilder.Property(prop => prop.Descricao)
            .IsRequired()
            .HasColumnName("AtaDescricao")
            .HasColumnType("text");

            modelBuilder.Property(prop => prop.IdAdmin)
            .IsRequired()
            .HasColumnName("IdAdmin")
            .HasColumnType("text");
        }   
    }
}