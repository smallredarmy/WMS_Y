using DAL;
using IDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALFactory {
    public class DBSession :IDBSession{
        public DbContext DBContext {
            get {
                return DBContextFactory.CreateDBContext();
            }
        }

        private IUserInfoDal _userInfoDal;
        public IUserInfoDal UserInfoDal {
            get {
                if (_userInfoDal == null) {
                    _userInfoDal = AbstractFactory.CreateUserInfoDal();
                }
                return _userInfoDal;
            }
        }

        public bool SaveChanges() {
            return DBContext.SaveChanges() > 0;
        }
    }
}
