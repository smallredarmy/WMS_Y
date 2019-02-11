using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL {
    public interface IDBSession {
        DbContext DBContext { get; }
        IUserInfoDal UserInfoDal { get; }
        bool SaveChanges();
    }
}
