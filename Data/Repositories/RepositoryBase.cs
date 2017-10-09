using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    //Repository Pattern
    //-Los repositorios se usan como manera de separa la logica que retorna los datos y los mapea al model de las entidades.
    //Mayor informacion:
    //https://msdn.microsoft.com/en-us/library/ff649690.aspx

    public abstract class RepositoryBase<TEntity> : IDisposable where TEntity : ObjectIdentificable
    {
        protected ApplicationContext context;

        public RepositoryBase()
        {
            context = new ApplicationContext();
        }
        
        protected DbSet<TEntity> DbSet {
            get
            {
                return context.Set<TEntity>();
            }
        }

        /// <summary>
        /// Retorna un objeto IQueryable con todo el conjunto de la tabla.
        /// </summary>
        public IQueryable<TEntity> All
        {
            get
            {
                return context.Set<TEntity>();                
            }
        }

        /// <summary>
        /// Permite especificar que objetos de navigacion se cargen junto con la consulta.
        /// </summary>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public IQueryable<TEntity> AllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = DbSet;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public void Delete(int id)
        {
            var entity = DbSet.Find(id);
            DbSet.Remove(entity);
        }
        public void Dispose()
        {
            context.Dispose();
        }
        public TEntity Find(int id)
        {
            return DbSet.Find(id);
        }
        public void InsertOrUpdate(TEntity entity)
        {
            if (entity.Id == default(int))
            {
                context.Entry(entity).State = EntityState.Added;
            }
            else
            {
                context.Entry(entity).State = EntityState.Modified;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }
        public Task<int> SaveAsync()
        {
            return context.SaveChangesAsync();
        }
    }
}
