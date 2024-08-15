using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCCLions.Domain.Data.Models;

namespace TCCLions.Infrastructure.Data.Configuration
{
    public class MembroConfiguration : IEntityTypeConfiguration<Membro>
    {
        public void Configure(EntityTypeBuilder<Membro> modelBuilder){
            modelBuilder.ToTable("Membro");

            modelBuilder.HasKey(prop => prop.Id);

            modelBuilder.Property(prop => prop.Nome)
            .IsRequired()
            .HasColumnName("Nome")
            .HasColumnType("varchar(50)");

            modelBuilder.Property(prop => prop.Endereco)
            .IsRequired()
            .HasColumnName("Endereco")
            .HasColumnType("varchar(50)");

            modelBuilder.Property(prop => prop.Bairro)
            .IsRequired()
            .HasColumnName("Bairro")
            .HasColumnType("varchar(50)");
            
            modelBuilder.Property(prop => prop.Cidade)
            .IsRequired()
            .HasColumnName("Cidade")
            .HasColumnType("varchar(50)");
            
            modelBuilder.Property(prop => prop.Cep)
            .IsRequired()
            .HasColumnName("Cep")
            .HasColumnType("varchar(10)");
            
            modelBuilder.Property(prop => prop.Email)
            .IsRequired()
            .HasColumnName("Email")
            .HasColumnType("varchar(80)");
            
            modelBuilder.Property(prop => prop.EstadoCivil)
            .IsRequired()
            .HasColumnName("EstadoCivil")
            .HasColumnType("varchar(50)");
            
            modelBuilder.Property(prop => prop.CPF)
            .IsRequired()
            .HasColumnName("CPF")
            .HasColumnType("varchar(11)");
           
        }
    }
}