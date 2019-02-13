using BLL;
using DAL.Enum;
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

        public ActionResult GetUserInfo() {
            int pageIndex = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int pageSize = Request["rows"] != null ? int.Parse(Request["rows"]) : 5;
            short delFlag = (short)DelFlagEnum.Normal;
            var userInfoList = userInfoService.LoadPageEntities<int>(pageIndex, pageSize, out int totalCount, u => u.DelFlag == delFlag, u => u.Id, true);

            var temp = from u in userInfoList
                       select new { u.Id, u.UName, u.UPwd, u.Remark, u.SubTime };
            return Json(new { rows = temp, total = totalCount }, JsonRequestBehavior.AllowGet);
        }
    }
}