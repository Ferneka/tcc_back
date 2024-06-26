﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TCCLions.Infrastructure.Data;

#nullable disable

namespace TCCLions.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDataContext))]
    [Migration("20240529171024_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("TCCLions.Domain.Data.Models.Administrador", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AdminLogin")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("AdminLogin");

                    b.Property<string>("AdminSenha")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("AdminSenha");

                    b.HasKey("Id");

                    b.ToTable("Administrador", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
