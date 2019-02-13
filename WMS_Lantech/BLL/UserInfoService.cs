using IBLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL {
    public class UserInfoService : BaseService<UserInfo>, IUserInfoService {
        public override void SetCurrentDal() {
            CurrentDal = CurrentDBSession.UserInfoDal;
        }
        public bool DeleteEntities(List<int> list) {
            var temp = CurrentDBSession.UserInfoDal.LoadEntities(c => list.Contains(c.Id));
            foreach (var userInfo in temp) {
                CurrentDal.DeleteEntity(userInfo);
            }
            return CurrentDBSession.SaveChanges();
        }

       
    }
}
