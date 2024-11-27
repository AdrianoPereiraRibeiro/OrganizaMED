﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrganizaMED.Infra.Orm.Compartilhado;

#nullable disable

namespace OrganizaMED.Infra.Migrations
{
    [DbContext(typeof(OrganizaMEDDbContext))]
    partial class OrganizaMEDDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OrganizaMED.Dominio.ModuloCirugia.Cirugia", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataDeEncerramento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("Duracao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TBCirugia", (string)null);
                });

            modelBuilder.Entity("OrganizaMED.Dominio.ModuloConsulta.Consulta", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataDeEncerramento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("Duracao")
                        .HasColumnType("int");

                    b.Property<Guid>("MedicoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MedicoId");

                    b.ToTable("TBConsulta", (string)null);
                });

            modelBuilder.Entity("OrganizaMED.Dominio.ModuloMedico.Medico", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.PrimitiveCollection<string>("Agenda")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CRM")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CirugiaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CirugiaId");

                    b.ToTable("TBMedico", (string)null);
                });

            modelBuilder.Entity("OrganizaMED.Dominio.ModuloConsulta.Consulta", b =>
                {
                    b.HasOne("OrganizaMED.Dominio.ModuloMedico.Medico", "Medico")
                        .WithMany()
                        .HasForeignKey("MedicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_TBMedico_TBConsulta");

                    b.Navigation("Medico");
                });

            modelBuilder.Entity("OrganizaMED.Dominio.ModuloMedico.Medico", b =>
                {
                    b.HasOne("OrganizaMED.Dominio.ModuloCirugia.Cirugia", null)
                        .WithMany("Medicos")
                        .HasForeignKey("CirugiaId");
                });

            modelBuilder.Entity("OrganizaMED.Dominio.ModuloCirugia.Cirugia", b =>
                {
                    b.Navigation("Medicos");
                });
#pragma warning restore 612, 618
        }
    }
}
