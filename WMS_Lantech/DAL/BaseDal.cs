using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL {
    public class BaseDal<T> where T : class, new() {
        public DbContext DBContext {
            get {
                return DBContextFactory.CreateDBContext();
            }
        }

        public bool AddEntity(T entity) {
            DBContext.Entry(entity).State = EntityState.Added;
            return true;
        }

        public bool DeleteEntity(T entity) {
            DBContext.Entry(entity).State = EntityState.Deleted;
            return true;
        }

        public bool EditEntity(T entity) {
            DBContext.Entry(entity).State = EntityState.Modified;
            return true;
        }

        public IQueryable<T> LoadEntities(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda) {
            return DBContext.Set<T>().Where(whereLambda);
        }

        public IQueryable<T> LoadPageEntities<S>(int pageIndex, int pageSize, out int totalCount, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, S>> orderbyLambda, bool isAsc) {
            var temp = DBContext.Set<T>().Where(whereLambda);
            totalCount = temp.Count();
            if (isAsc) {
                temp = temp.OrderBy(orderbyLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            } else {
                temp = temp.OrderByDescending(orderbyLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            return temp;
        }
    }
}
