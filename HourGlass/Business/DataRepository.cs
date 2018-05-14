using Business.Interface;
using Datastore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class DataRepository<T> : IDisposable, IDataRepository<T> where T : Base, Datastore.IEntity
    {
        private HourGlassContext _context;

        public DataRepository(HourGlassContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async virtual Task<IList<T>> GetAllAsync(params Expression<Func<T, object>>[] navigationProperties)
        {
            IList<T> list;
            IQueryable<T> dbQuery = _context.Set<T>();

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            list = await dbQuery
                .ToListAsync<T>();
            return list;
        }

        public virtual IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            IList<T> list;
            IQueryable<T> dbQuery = _context.Set<T>();

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            list = dbQuery
                 .ToList();
            return list;
        }

        public async virtual Task<IList<T>> GetListAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IList<T> list;

            IQueryable<T> dbQuery = _context.Set<T>();

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            list = await dbQuery
                .Where(where)
                .ToListAsync<T>();

            return list;
        }

        public virtual IList<T> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IList<T> list;

            IQueryable<T> dbQuery = _context.Set<T>();

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            list = dbQuery
                .Where(where)
                .ToList();

            return list;
        }

        public virtual IList<T> GetPagedList(Expression<Func<T, bool>> where, Func<T, string> orderBy, int currentPage, int pageSize, params Expression<Func<T, object>>[] navigationProperties)
        {
            IList<T> list;

            IQueryable<T> dbQuery = _context.Set<T>();

            //calculate item skip
            int skip = (currentPage - 1) * pageSize;

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
            {
                if (navigationProperty != null)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);
            }

            list = dbQuery
                .Where(where).OrderBy(orderBy).Skip(skip).Take(pageSize)
                .ToList();

            return list;
        }

        public virtual int GetCount(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _context.Set<T>();

            if (navigationProperties != null)
            {
                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                {
                    if (navigationProperty != null)
                        dbQuery = dbQuery.Include<T, object>(navigationProperty);
                }
            }

            int count = dbQuery
                .Where(where)
                .Count();

            return count;
        }

        public async virtual Task<T> GetSingleAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            T item = null;

            IQueryable<T> dbQuery = _context.Set<T>();

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            item = await dbQuery
                .FirstOrDefaultAsync(predicate: where); //Apply where clause
            return item;
        }

        public virtual T GetSingle(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            T item = null;

            IQueryable<T> dbQuery = _context.Set<T>();

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            item = dbQuery.FirstOrDefault(predicate: where); //Apply where clause
            return item;
        }

        public virtual void DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> entities = _context.Set<T>().Where(predicate);

            foreach (var entity in entities)
            {
                _context.Entry<T>(entity).State = GetEntityState(Datastore.EntityState.Deleted);
            }

            _context.SaveChanges();
        }

        public virtual void Add(params T[] items)
        {
            foreach (var item in items)
            {
                item.entity_state = Datastore.EntityState.Added;
            }
            updateRepository(items);
        }

        public virtual void Delete(params T[] items)
        {
            foreach (var item in items)
            {
                item.entity_state = Datastore.EntityState.Deleted;
                item.IsDeleted = true;
            }
            updateRepository(items);
        }

        public virtual void Update(params T[] items)
        {
            foreach (var item in items)
            {
                item.entity_state = Datastore.EntityState.Modified;
            }
            updateRepository(items);


        }

        private void updateRepository(params T[] items)
        {
            foreach (T item in items)
            {
                EntityEntry dbEntityEntry = _context.Entry<T>(item);

                if (item.entity_state == Datastore.EntityState.Added)
                {
                    _context.Set<T>().Add(item);
                }

                dbEntityEntry.State = GetEntityState(item.entity_state);
            }

            _context.SaveChanges();
        }

        protected static Microsoft.EntityFrameworkCore.EntityState GetEntityState(Datastore.EntityState entityState)
        {
            switch (entityState)
            {
                case Datastore.EntityState.Unchanged:
                    return Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                case Datastore.EntityState.Added:
                    return Microsoft.EntityFrameworkCore.EntityState.Added;
                case Datastore.EntityState.Modified:
                    return Microsoft.EntityFrameworkCore.EntityState.Modified;
                case Datastore.EntityState.Deleted:
                    return Microsoft.EntityFrameworkCore.EntityState.Deleted;
                default:
                    return Microsoft.EntityFrameworkCore.EntityState.Detached;
            }
        }
    }
}
