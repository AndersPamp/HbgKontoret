﻿// <auto-generated />
using System;
using HbgKontoret.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HbgKontoret.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.HasKey("Id");

                    b.ToTable("Competences");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "DOTNET"
                        },
                        new
                        {
                            Id = 2,
                            Name = "JS"
                        },
                        new
                        {
                            Id = 3,
                            Name = "React"
                        },
                        new
                        {
                            Id = 4,
                            Name = "EpiServer"
                        },
                        new
                        {
                            Id = 5,
                            Name = "C#"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Angular"
                        });
                });

            modelBuilder.Entity("HbgKontoret.Data.Entities.Links.ProfileCompetence", b =>
                {
                    b.Property<Guid>("ProfileId");

                    b.Property<int>("CompetenceId");

                    b.HasKey("ProfileId", "CompetenceId");

                    b.HasIndex("CompetenceId");

                    b.ToTable("ProfileCompetences");

                    b.HasData(
                        new
                        {
                            ProfileId = new Guid("c3178cd5-3615-4ebe-97f6-88da54a2ce21"),
                            CompetenceId = 3
                        },
                        new
                        {
                            ProfileId = new Guid("c3178cd5-3615-4ebe-97f6-88da54a2ce21"),
                            CompetenceId = 1
                        },
                        new
                        {
                            ProfileId = new Guid("2ed8c7ca-6061-4308-86cc-61d73119b431"),
                            CompetenceId = 2
                        },
                        new
                        {
                            ProfileId = new Guid("2ed8c7ca-6061-4308-86cc-61d73119b431"),
                            CompetenceId = 4
                        },
                        new
                        {
                            ProfileId = new Guid("02a9ee1c-fa0d-4e61-82e3-78a592eff671"),
                            CompetenceId = 2
                        },
                        new
                        {
                            ProfileId = new Guid("02a9ee1c-fa0d-4e61-82e3-78a592eff671"),
                            CompetenceId = 3
                        });
                });

            modelBuilder.Entity("HbgKontoret.Data.Entities.Links.ProfileOffice", b =>
                {
                    b.Property<Guid>("ProfileId");

                    b.Property<int>("OfficeId");

                    b.HasKey("ProfileId", "OfficeId");

                    b.HasIndex("OfficeId");

                    b.ToTable("ProfileOffices");

                    b.HasData(
                        new
                        {
                            ProfileId = new Guid("c3178cd5-3615-4ebe-97f6-88da54a2ce21"),
                            OfficeId = 1
                        },
                        new
                        {
                            ProfileId = new Guid("c3178cd5-3615-4ebe-97f6-88da54a2ce21"),
                            OfficeId = 2
                        },
                        new
                        {
                            ProfileId = new Guid("2ed8c7ca-6061-4308-86cc-61d73119b431"),
                            OfficeId = 1
                        },
                        new
                        {
                            ProfileId = new Guid("02a9ee1c-fa0d-4e61-82e3-78a592eff671"),
                            OfficeId = 2
                        });
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Considvägen 1",
                            Manager = "Christian",
                            Name = "Helsingborg",
                            Phone = "042-123456"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Considvägen 2",
                            Manager = "Peter",
                            Name = "Jönköping",
                            Phone = "036-321654"
                        });
                });

            modelBuilder.Entity("HbgKontoret.Data.Entities.Profile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AboutMe");

                    b.Property<string>("FirstName");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("LastName");

                    b.Property<string>("LinkedInUrl");

                    b.Property<string>("Manager");

                    b.Property<string>("PhoneNo");

                    b.HasKey("Id");

                    b.ToTable("Profiles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c3178cd5-3615-4ebe-97f6-88da54a2ce21"),
                            AboutMe = "Spielt Allan allein",
                            FirstName = "Ruler",
                            LastName = "OfTheWorld"
                        },
                        new
                        {
                            Id = new Guid("2ed8c7ca-6061-4308-86cc-61d73119b431"),
                            AboutMe = "Ich bin ein Dorftrottel",
                            FirstName = "Robin",
                            LastName = "Robinovic",
                            Manager = "Christian"
                        },
                        new
                        {
                            Id = new Guid("02a9ee1c-fa0d-4e61-82e3-78a592eff671"),
                            AboutMe = "Lorem ipsum",
                            FirstName = "Salmin",
                            LastName = "Salminovic",
                            Manager = "Peter"
                        });
                });

            modelBuilder.Entity("HbgKontoret.Data.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Visitor"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Member"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Manager"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Administrator"
                        });
                });

            modelBuilder.Entity("HbgKontoret.Data.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<Guid?>("ProfileId");

                    b.Property<int?>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("53019d21-e997-406d-bc36-6627c078e6a5"),
                            Email = "admin@consid.se",
                            Password = "secret123!",
                            RoleId = 4
                        },
                        new
                        {
                            Id = new Guid("97de5fdb-e995-4289-a753-39657ee08a11"),
                            Email = "robin@consid.se",
                            Password = "consid01",
                            RoleId = 3
                        },
                        new
                        {
                            Id = new Guid("84a23a45-1dc8-471d-b0ae-c11b3c2b014b"),
                            Email = "salmin@consid.se",
                            Password = "consid02",
                            RoleId = 2
                        },
                        new
                        {
                            Id = new Guid("2d11321b-72a4-492e-a9cb-becb72164fa4"),
                            Email = "janedoe@nomail.com",
                            Password = "visitor01",
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("HbgKontoret.Data.Entities.Links.ProfileCompetence", b =>
                {
                    b.HasOne("HbgKontoret.Data.Entities.Competence", "Competence")
                        .WithMany("ProfileCompetences")
                        .HasForeignKey("CompetenceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HbgKontoret.Data.Entities.Profile", "Profile")
                        .WithMany("ProfileCompetences")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HbgKontoret.Data.Entities.Links.ProfileOffice", b =>
                {
                    b.HasOne("HbgKontoret.Data.Entities.Office", "Office")
                        .WithMany("ProfileOffices")
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HbgKontoret.Data.Entities.Profile", "Profile")
                        .WithMany("ProfileOffices")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HbgKontoret.Data.Entities.User", b =>
                {
                    b.HasOne("HbgKontoret.Data.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });
#pragma warning restore 612, 618
        }
    }
}
