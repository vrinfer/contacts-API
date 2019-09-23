using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    public class ContacDbContext : DbContext, IContacDbContext
    {
        public ContacDbContext(DbContextOptions<ContacDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Contact> Contacts { get; set ; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contact>().HasKey(x => new { x.Id });
            modelBuilder.Entity<ContactInformation>().HasKey(x => new { x.Id });
        }

        public void Save()
        {
            this.SaveChanges();
        }
    }
}
