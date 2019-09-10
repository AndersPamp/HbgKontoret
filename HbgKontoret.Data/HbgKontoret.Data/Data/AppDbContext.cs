using HbgKontoret.Data.Entities;
using HbgKontoret.Data.Entities.Links;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;


namespace HbgKontoret.Data.Data
{
  public class AppDbContext : DbContext
  {
    public DbSet<Login> Logins { get; set; }
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
    }
  }
}
