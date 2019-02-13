using IBLL;
using Model;
using Model.SearchParam;
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
        /// <summary>
        /// 多条件搜索
        /// </summary>
        /// <param name="userInfoParam"></param>
        /// <returns></returns>
        public IQueryable<UserInfo> LoadSearchEntities(UserInfoParam userInfoParam) {
            var temp = CurrentDBSession.UserInfoDal.LoadEntities(u => u.DelFlag == 0);
            if (!string.IsNullOrEmpty(userInfoParam.UName)) {
                temp = temp.Where(u => u.UName.Contains(userInfoParam.UName));
            }
            if (!string.IsNullOrEmpty(userInfoParam.Remark)) {
                temp = temp.Where(u => u.Remark.Contains(userInfoParam.Remark));
            }
            userInfoParam.TotalCount = temp.Count();
            return temp.OrderBy<UserInfo, int>(u => u.Id).Skip((userInfoParam.PageIndex - 1) * userInfoParam.PageSize).Take(userInfoParam.PageSize);
        }
    }
}
