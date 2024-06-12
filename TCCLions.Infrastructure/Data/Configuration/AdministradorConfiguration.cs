using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TCCLions.Domain.Data;
using TCCLions.Domain.Data.Models;

namespace TCCLions.Infrastructure.Data.Configuration
{
    public class AdministradorConfiguration : IEntityTypeConfiguration<Administrador>
    {
        public void Configure(EntityTypeBuilder<Administrador> modelBuilder){
            modelBuilder.ToTable("Administrador");
            
            modelBuilder.HasKey(prop => prop.Id);

            modelBuilder.Property(prop => prop.AdminLogin)
            .IsRequired()
            .HasColumnName("AdminLogin")
            .HasColumnType("varchar(50)");

            modelBuilder.Property(prop => prop.AdminSenha)
            .IsRequired()
            .HasColumnName("AdminSenha")
            .HasColumnType("varchar(50)");
        }
    }
}