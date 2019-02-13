using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DAL {
    public class DBContextFactory {
        public static DbContext CreateDBContext() {
            DbContext db = (DbContext)CallContext.GetData("dbContext");
            if (db == null) {
                db = new OAEntities();
                CallContext.SetData("dbContext", db);
            }
            return db;
        }
    }
}
