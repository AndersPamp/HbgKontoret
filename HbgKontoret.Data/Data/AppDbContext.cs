using System;
using System.Collections.Generic;
using System.Text;
using HbgKontoret.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HbgKontoret.Data.Data
{
  public class AppDbContext : DbContext
  {
    public DbSet<Login> Users { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
  }
}
