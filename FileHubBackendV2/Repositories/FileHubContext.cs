using FileHubBackendV2.Extensions;
using FileHubBackendV2.Models;
using Microsoft.EntityFrameworkCore;

namespace FileHubBackendV2.Repositories
{
    public class FileHubContext: DbContext
    {
        public DbSet<CityFeDto> Cities { get; set; }
        public DbSet<FileFeDto> Files { get; set; }

        public FileHubContext() {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string cn = @"Server=(localdb)\mssqllocaldb;Database=FileHubDevDb;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(cn);
            
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }

    }
}
