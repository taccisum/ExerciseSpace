using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.UserManager;
using HelperUnit.Extend;
using HelperUnit.Units;
using IBLL.UserManager;
using log4net;
using Model.Models;
using GlobalContext = Global.Configs.GlobalContext;

namespace Practice.Controllers
{
    public class UserController : BaseController
    {
        private IUserBusiness _userBusiness;

        public UserController()
        {
            _userBusiness = new UserBusiness();
        }

        public ActionResult Login()
        {
            return View();
        }


        public ActionResult Verify(string uid, string psd, bool remeber)
        {
            Log.Info("用户\"" + uid + "\"尝试验证登录");

            var id = _userBusiness.LoginVerify(uid, psd);
            var valid = id != Guid.Empty;

            if (valid)
            {
                if (remeber)
                {
                    var token = _userBusiness.GenerateAutoLoginToken();
                    CookiesHelper.Add(GlobalContext.AUTOLOGIN.ToMD5(), token.ToString(), DateTime.Now.AddHours(2));
                }
                CookiesHelper.Add(GlobalContext.CURRENT_USER.ToMD5(), id.ToString(), DateTime.Now.AddHours(2));
            }

            Log.Info("用户\"" + uid + "\"登录" + (valid ? "成功" : "失败"));

            return Json(valid, JsonRequestBehavior.DenyGet);
        }
    }
}