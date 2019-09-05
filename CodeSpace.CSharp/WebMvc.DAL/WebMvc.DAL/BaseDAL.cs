using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using WebMvc.Model.BBSAdmin;
using WebMvc.DAL.BBSAdmin;

namespace WebMvc.DAL
{
    public class BaseDAL<T> where T:class,new()
    {
        private DbContext dbContext = DbContextFactory.Create();
        public void Add(T t)
        {
            dbContext.Set<T>().Add(t);
        }
        public void Delete(T t)
        {
            dbContext.Set<T>().Remove(t);
        }

        public void Update(T t)
        {
            dbContext.Set<T>().Update(t);
        }

        public IQueryable<T> GetModels(Expression<Func<T, bool>> whereLambda)
        {
            return dbContext.Set<T>().Where(whereLambda);
        }

        public IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc,
            Expression<Func<T, type>> OrderByLambda, Expression<Func<T, bool>> WhereLambda)
        {
            //是否升序
            if (isAsc)
            {
                return dbContext.Set<T>().Where(WhereLambda).OrderBy(OrderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            else
            {
                return dbContext.Set<T>().Where(WhereLambda).OrderByDescending(OrderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
        }

        public bool SaveChanges()
        {
            return dbContext.SaveChanges() > 0;
        }
    }
}
