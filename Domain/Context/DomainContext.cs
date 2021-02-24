using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Context
{
    public class DomainContext : DbContext
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<States> States { get; set; }
        public DbSet<IdentificationType> IdentificationType { get; set; }
        public DbSet<Documents> Document { get; set; }
        public DbSet<DocumentType> DocumentType { get; set; }
        public DbSet<RolMenu> RolMenu { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<ConsecutiveConfig> ConsecutiveConfig { get; set; }


        public DomainContext(DbContextOptions<DomainContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
