using System;
using Microsoft.EntityFrameworkCore;
using ReDoMusic.Domain.Entites;


namespace ReDoMusic.Persistence.Context
{
    public class ReDoMusicDbContext : DbContext
    {
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Configurations.GetString("ConnectionStrings:PostgreSQL"));
        }

    }
}