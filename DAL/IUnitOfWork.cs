using DAL.Models;

namespace DAL
{
    public interface IUnitOfWork
    {
        ContextRepository<Role> Roles { get; }

        ContextRepository<User> Users { get; }

        ContextRepository<Tour> Tours { get; }

        ContextRepository<City> Cities { get; }

        void Save();
        void Dispose();
    }
}
