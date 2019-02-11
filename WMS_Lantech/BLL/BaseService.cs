using DALFactory;
using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL {
    public abstract class BaseService<T> where T : class, new() {
        public IDBSession CurrentDBSession {
            get {
                return DBSessionFactory.CreateDBSession();
            }
        }

        public IBaseDal<T> CurrentDal {
            get; set;
        }

        public abstract void SetCurrentDal();

        public BaseService() {
            SetCurrentDal();
        }

        public bool AddEntity(T entity) {
            CurrentDal.AddEntity(entity);
            return CurrentDBSession.SaveChanges();
        }

        public bool DeleteEntity(T entity) {
            CurrentDal.DeleteEntity(entity);
            return CurrentDBSession.SaveChanges();
        }

        public bool EditEntity(T entity) {
            CurrentDal.EditEntity(entity);
            return CurrentDBSession.SaveChanges();
        }

        public IQueryable<T> LoadEntities(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda) {
            return CurrentDal.LoadEntities(whereLambda);
        }

        public IQueryable<T> LoadPageEntities<S>(int pageIndex, int pageSize, out int totalCount, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, S>> orderbyLambda, bool isAsc) {
            return CurrentDal.LoadPageEntities<S>(pageIndex, pageSize, out totalCount, whereLambda, orderbyLambda, isAsc);
        }


    }
}
