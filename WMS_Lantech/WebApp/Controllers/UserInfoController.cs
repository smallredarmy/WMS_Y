using BLL;
using IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers {
    public class UserInfoController : Controller {
        public IUserInfoService userInfoService = new UserInfoService();
        // GET: UserInfo
        public ActionResult Index() {
            var temp = userInfoService.LoadEntities(u => true);
            return View(temp.ToList());
        }
    }
}