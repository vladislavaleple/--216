using DAL.Models;
using System.Data.Entity;

namespace DAL
{
    public class Context : DbContext
    {
        public Context()
           : base("name=TravelDatabase")
        {

        }

        public DbSet<Role> Roles { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Tour> Tours { get; set; }

        public DbSet<City> Cities { get; set; }
    }
}
