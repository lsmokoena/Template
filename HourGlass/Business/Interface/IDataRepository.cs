﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IDataRepository<T> where T : class, Datastore.IEntity
    {
        Task<IList<T>> GetAllAsync(params Expression<Func<T, object>>[] navigationProperties);
        Task<IList<T>> GetListAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties);
        IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);
        IList<T> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties);
        IList<T> GetPagedList(Expression<Func<T, bool>> where, Func<T, string> orderBy, int currentPage, int pageSize, params Expression<Func<T, object>>[] navigationProperties);

        int GetCount(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties);

        T GetSingle(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties);

        //Task<> Update(params T[] items);

        void Update(params T[] items);
        void Add(params T[] items);
        void Delete(params T[] items);
        void DeleteWhere(Expression<Func<T, bool>> predicate);
    }
}
