﻿// <auto-generated />
using System;
using HbgKontoret.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HbgKontoret.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190902093036_revise_entities")]
    partial class revise_entities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HbgKontoret.Data.Entities.Competence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<Guid?>("ProfileId");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("Competences");
                });

            modelBuilder.Entity("HbgKontoret.Data.Entities.Links.ProfileCompetence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompetenceId");

                    b.Property<Guid>("ProfileId");

                    b.HasKey("Id");

                    b.HasIndex("CompetenceId");

                    b.HasIndex("ProfileId");

                    b.ToTable("ProfileCompetences");
                });

            modelBuilder.Entity("HbgKontoret.Data.Entities.Links.ProfileOffice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OfficeId");

                    b.Property<Guid>("ProfileId");

                    b.HasKey("Id");

                    b.HasIndex("OfficeId");

                    b.HasIndex("ProfileId");

                    b.ToTable("ProfileOffices");
                });

            modelBuilder.Entity("HbgKontoret.Data.Entities.Login", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password");

                    b.Property<string>("Token");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("HbgKontoret.Data.Entities.Office", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Manager");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.HasKey("Id");

                    b.ToTable("Offices");
                });

            modelBuilder.Entity("HbgKontoret.Data.Entities.Profile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AboutMe");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("LinkedInUrl");

                    b.Property<string>("Manager");

                    b.Property<string>("PhoneNo");

                    b.HasKey("Id");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("HbgKontoret.Data.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid?>("LoginId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("LoginId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("HbgKontoret.Data.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HbgKontoret.Data.Entities.Competence", b =>
                {
                    b.HasOne("HbgKontoret.Data.Entities.Profile")
                        .WithMany("Competences")
                        .HasForeignKey("ProfileId");
                });

            modelBuilder.Entity("HbgKontoret.Data.Entities.Links.ProfileCompetence", b =>
                {
                    b.HasOne("HbgKontoret.Data.Entities.Competence", "Competence")
                        .WithMany()
                        .HasForeignKey("CompetenceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HbgKontoret.Data.Entities.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HbgKontoret.Data.Entities.Links.ProfileOffice", b =>
                {
                    b.HasOne("HbgKontoret.Data.Entities.Office", "Office")
                        .WithMany()
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HbgKontoret.Data.Entities.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HbgKontoret.Data.Entities.Role", b =>
                {
                    b.HasOne("HbgKontoret.Data.Entities.Login")
                        .WithMany("Roles")
                        .HasForeignKey("LoginId");
                });
#pragma warning restore 612, 618
        }
    }
}
