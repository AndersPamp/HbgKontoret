using System;
using System.Collections.Generic;
using HbgKontoret.Data.Entities;
using HbgKontoret.Data.Entities.Links;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace HbgKontoret.Data.Data
{
  public class AppDbContext : DbContext
  {
    public DbSet<User> Users { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Office> Offices { get; set; }
    public DbSet<Competence> Competences { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<ProfileCompetence> ProfileCompetences { get; set; }
    public DbSet<ProfileOffice> ProfileOffices { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

      modelBuilder.Entity<ProfileCompetence>().HasKey(x => new { x.ProfileId, x.CompetenceId });
      modelBuilder.Entity<ProfileOffice>().HasKey(x => new { x.ProfileId, x.OfficeId });

      modelBuilder.Entity<Role>().HasData(new List<Role>
      {
        new Role{Id = 1, Name = "Visitor"},
        new Role{Id = 2, Name = "Member"},
        new Role{Id = 3, Name = "Manager"},
        new Role{Id = 4, Name = "Administrator"}
      });

      modelBuilder.Entity<User>().HasData(new
      {
        Id = Guid.Parse("53019D21-E997-406D-BC36-6627C078E6A5"),
        Email = "admin@consid.se",
        Password = "secret123!",
        RoleId = 4
      });
      modelBuilder.Entity<User>().HasData(new
      {
        Id = Guid.Parse("97DE5FDB-E995-4289-A753-39657EE08A11"),
        Email = "robin@consid.se",
        Password = "consid01",
        RoleId = 3
      });
      modelBuilder.Entity<User>().HasData(new
      {
        Id = Guid.Parse("84A23A45-1DC8-471D-B0AE-C11B3C2B014B"),
        Email = "salmin@consid.se",
        Password = "consid02",
        RoleId = 2
      });
      modelBuilder.Entity<User>().HasData(new
      {
        Id = Guid.Parse("2D11321B-72A4-492E-A9CB-BECB72164FA4"),
        Email = "janedoe@nomail.com",
        Password = "visitor01",
        RoleId = 1
      });

      modelBuilder.Entity<Competence>().HasData(new List<Competence>
      {
        new Competence{Id = 1, Name = "DOTNET"},
        new Competence{Id = 2, Name="JS"},
        new Competence{Id = 3, Name = "React"},
        new Competence{Id = 4, Name = "EpiServer"},
        new Competence{Id = 5, Name = "C#"},
        new Competence{Id = 6, Name = "Angular"}
      });

      modelBuilder.Entity<Profile>().HasData(new List<Profile>
      {
        new Profile
        {
          Id = Guid.Parse("C3178CD5-3615-4EBE-97F6-88DA54A2CE21"),
          AboutMe = "Spielt Allan allein",
          FirstName = "Ruler",
          LastName = "OfTheWorld"
        },
        new Profile
        {
          Id = Guid.Parse("2ED8C7CA-6061-4308-86CC-61D73119B431"),
          AboutMe = "Ich bin ein Dorftrottel",
          FirstName = "Robin",
          LastName = "Robinovic",
          Manager = "Christian"
        },
        new Profile
        {
          Id = Guid.Parse("02A9EE1C-FA0D-4E61-82E3-78A592EFF671"),
          AboutMe = "Lorem ipsum",
          FirstName = "Salmin",
          LastName = "Salminovic",
          Manager = "Peter"
        }
      });

      modelBuilder.Entity<Office>().HasData(new List<Office>
      {
        new Office
        {
          Address = "Considvägen 1",
          Manager = "Christian",
          Id = 1,
          Name = "Helsingborg",
          Phone = "042-123456"
        },
        new Office
        {
          Address = "Considvägen 2",
          Manager = "Peter",
          Id = 2,
          Name = "Jönköping",
          Phone = "036-321654"
        }
      });

      modelBuilder.Entity<ProfileCompetence>().HasData(new List<ProfileCompetence>
      {
        new ProfileCompetence{CompetenceId = 3, ProfileId = Guid.Parse("C3178CD5-3615-4EBE-97F6-88DA54A2CE21")},
        new ProfileCompetence{CompetenceId = 1, ProfileId = Guid.Parse("C3178CD5-3615-4EBE-97F6-88DA54A2CE21")},
        new ProfileCompetence{CompetenceId = 2, ProfileId = Guid.Parse("2ED8C7CA-6061-4308-86CC-61D73119B431")},
        new ProfileCompetence{CompetenceId = 4, ProfileId = Guid.Parse("2ED8C7CA-6061-4308-86CC-61D73119B431")},
        new ProfileCompetence{CompetenceId = 2, ProfileId = Guid.Parse("02A9EE1C-FA0D-4E61-82E3-78A592EFF671")},
        new ProfileCompetence{CompetenceId = 3, ProfileId = Guid.Parse("02A9EE1C-FA0D-4E61-82E3-78A592EFF671")}
      });

      modelBuilder.Entity<ProfileOffice>().HasData(new List<ProfileOffice>
      {
        new ProfileOffice{OfficeId = 1, ProfileId = Guid.Parse("C3178CD5-3615-4EBE-97F6-88DA54A2CE21")},
        new ProfileOffice{OfficeId = 2, ProfileId = Guid.Parse("C3178CD5-3615-4EBE-97F6-88DA54A2CE21")},
        new ProfileOffice{OfficeId = 1, ProfileId = Guid.Parse("2ED8C7CA-6061-4308-86CC-61D73119B431")},
        new ProfileOffice{OfficeId = 2, ProfileId = Guid.Parse("02A9EE1C-FA0D-4E61-82E3-78A592EFF671")}
      });

      //Github suger röv!
    }
  }
}
