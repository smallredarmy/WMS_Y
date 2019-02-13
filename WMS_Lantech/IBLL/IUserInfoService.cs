using Model;
using Model.SearchParam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL {
    public interface IUserInfoService: IBaseService<UserInfo> {
        bool DeleteEntities(List<int> list);
        IQueryable<UserInfo> LoadSearchEntities(UserInfoParam userInfoParam);
    }
}
