using Microsoft.EntityFrameworkCore;
using Buddy.Models;
namespace Buddy.Data
{
    public class BuddyDbContext : DbContext
    {
        public BuddyDbContext()
        {
        }

        public BuddyDbContext(DbContextOptions<BuddyDbContext> options)
        :base(options)
        {

        }
        public DbSet<Employee>Employees{get;set;}
        public DbSet<Candidate> Candidates{get;set;}
        public DbSet<Branch> Branches {get;set;}

    }
}