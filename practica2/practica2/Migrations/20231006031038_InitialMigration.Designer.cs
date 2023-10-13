﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using practica2.conte;

#nullable disable

namespace practica2.Migrations
{
    [DbContext(typeof(appDbcontex))]
    [Migration("20231006031038_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("practica2.model.docente", b =>
                {
                    b.Property<int>("Id_Doce")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_Doce"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Ci")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Id_uni")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Sexo")
                        .HasColumnType("boolean");

                    b.Property<string>("Ubicacion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id_Doce");

                    b.HasIndex("Id_uni");

                    b.ToTable("docentes");
                });

            modelBuilder.Entity("practica2.model.estudiante", b =>
                {
                    b.Property<int>("Id_estu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_estu"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Edad")
                        .HasColumnType("integer");

                    b.Property<int>("Id_uni")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Sexo")
                        .HasColumnType("boolean");

                    b.HasKey("Id_estu");

                    b.HasIndex("Id_uni");

                    b.ToTable("estudiantes");
                });

            modelBuilder.Entity("practica2.model.universidad", b =>
                {
                    b.Property<int>("Id_uni")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_uni"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id_uni");

                    b.ToTable("universidad");
                });

            modelBuilder.Entity("practica2.model.docente", b =>
                {
                    b.HasOne("practica2.model.universidad", "universidad")
                        .WithMany()
                        .HasForeignKey("Id_uni")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("universidad");
                });

            modelBuilder.Entity("practica2.model.estudiante", b =>
                {
                    b.HasOne("practica2.model.universidad", "universidad")
                        .WithMany()
                        .HasForeignKey("Id_uni")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("universidad");
                });
#pragma warning restore 612, 618
        }
    }
}
