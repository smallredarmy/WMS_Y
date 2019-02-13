using BLL;

using IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers {
    public class UserInfoController : Controller {
        IUserInfoService userInfoService = new UserInfoService();
        // GET: UserInfo
        public ActionResult Index() {

            return View();
        }

        #region 获取数据
        public ActionResult GetUserInfo() {
            int pageIndex = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int pageSize = Request["rows"] != null ? int.Parse(Request["rows"]) : 5;
            
            var userInfoList = userInfoService.LoadPageEntities<int>(pageIndex, pageSize, out int totalCount, u => u.DelFlag == 0, u => u.Id, true);

            var temp = from u in userInfoList
                       select new { u.Id, u.UName, u.UPwd, u.Remark, u.SubTime };
            return Json(new { rows = temp, total = totalCount }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 删除数据
        public ActionResult DeleteUserInfo() {
            string strId = Request["strId"];
            string[] strIds = strId.Split(',');
            List<int> list = new List<int>();
            foreach (var item in strIds) {
                list.Add(int.Parse(item));
            }
            if (userInfoService.DeleteEntities(list)) {
                return Content("ok");
            } else {
                return Content("error");
            }

        }
        #endregion
    }
}