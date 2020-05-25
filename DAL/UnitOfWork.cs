using DAL.Models;
using System;

namespace DAL
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly Context BD;

        public ContextRepository<Role> Roles { get; }

        public ContextRepository<User> Users { get; }

        public ContextRepository<Tour> Tours { get; }

        public ContextRepository<City> Cities { get; }


        private bool Disposed;

        public UnitOfWork(Context bD, ContextRepository<Role> roles, ContextRepository<User> users, ContextRepository<Tour> tours, ContextRepository<City> cities)
        {
            BD = bD;
            Roles = roles;
            Users = users;
            Tours = tours;
            Cities = cities;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (Disposed) return;
            if (disposing)
            {
                BD.Dispose();
            }

            Disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            BD.SaveChanges();
        }
    }
}
