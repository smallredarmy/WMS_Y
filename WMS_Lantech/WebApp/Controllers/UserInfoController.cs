using BLL;

using IBLL;
using Model;
using Model.SearchParam;
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
            string name = Request["name"];
            string remark = Request["remark"];
            int totalCount = 0;
            //构建搜索条件
            UserInfoParam userInfoParam = new UserInfoParam() {
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalCount = totalCount,
                UName = name,
                Remark = remark
            };


            //var userInfoList = userInfoService.LoadPageEntities<int>(pageIndex, pageSize, out totalCount, u => u.DelFlag == 0, u => u.Id, true);
            var userInfoList = userInfoService.LoadSearchEntities(userInfoParam);

            var temp = from u in userInfoList
                       select new { u.Id, u.UName, u.UPwd, u.Remark, u.SubTime };
            return Json(new { rows = temp, total = userInfoParam.TotalCount }, JsonRequestBehavior.AllowGet);
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

        #region 添加数据
        public ActionResult AddUserInfo(UserInfo userInfo) {
            userInfo.DelFlag = 0;
            userInfo.ModifiedOn = DateTime.Now;
            userInfo.SubTime = DateTime.Now;
            userInfoService.AddEntity(userInfo);
            return Content("ok");
        }
        #endregion

        #region 显示要修改的数据
        public ActionResult ShowEditInfo() {
            int Id = int.Parse(Request["Id"]);
            UserInfo userInfo = userInfoService.LoadEntities(u => u.Id == Id).FirstOrDefault();
            if (userInfo != null) {
                return Json(new { serverData = userInfo, msg = "ok" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { msg = "error" }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 修改数据
        public ActionResult EditUserInfo(UserInfo userInfo ) {
            userInfo.ModifiedOn = DateTime.Now;
            if (userInfoService.EditEntity(userInfo)) {
                return Content("ok");
            } else {
                return Content("error");
            }
            
        }
        #endregion
    }
}