using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.SysMenuManager;
using IBLL.SysMenuManager;
using Model.Common;

namespace Practice.Controllers
{
    public class CommonInfoController : BaseController
    {
        public ActionResult Menus()
        {
            try
            {
                ISysMenuBusiness menuBusiness = new SysMenuBusiness();
                var menus = menuBusiness.Get().OrderBy(m=>m.CreatedOn);
                return Json(ApiResult.SuccessResult(menus), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Log.Error("获取菜单信息失败", e);
            }

            return Json(ApiResult.FailedResult("获取菜单信息失败"), JsonRequestBehavior.AllowGet);
        }




        public ActionResult NonAuthority()
        {
            return View();
        }
    }
}