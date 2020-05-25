using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public sealed class ContextRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly Context Context;
        private readonly DbSet<TEntity> dataSet;


        public ContextRepository(Context context)
        {

            Context = context;
            dataSet = context.Set<TEntity>();
        }

        public void Create(TEntity item)
        {
            using (Context db = new Context())
            {
                dataSet.Add(item);
            }
        }

        public TEntity FindById(int id)
        {
            return dataSet.Find(id);
        }

        public IEnumerable<TEntity> Get()
        {
            return dataSet.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return dataSet.Where(predicate).ToList();
        }

        public TEntity GetOne(Func<TEntity, bool> predicate)
        {
            return dataSet.Where(predicate).FirstOrDefault();
        }

        public void Remove(TEntity item)
        {
            try
            {
                dataSet.Remove(item);
            }
            catch (ArgumentNullException)
            {

            }
        }

        public void Update(TEntity item)
        {
            Context.Entry(item).State = EntityState.Modified;
        }


    }
}
