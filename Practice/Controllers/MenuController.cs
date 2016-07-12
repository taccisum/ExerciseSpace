using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.SysMenuManager;
using IBLL.SysMenuManager;
using Model.Entity;

namespace Practice.Controllers
{
    public class MenuController : BaseController
    {
        private ISysMenuBusiness _menuBusiness = new SysMenuBusiness();

        // GET: Menu
        public ActionResult MenuList()
        {
            return View();
        }


        public ActionResult GetMenusList(int pageindex)
        {
            if (Log.IsInfoEnabled)
                Log.Info("获取用户列表", new ApplicationException("hahaha"));


            var menus = RepositoryFactory.At<SysMenu>();
            var list = menus.Get();

            var tableData = new
            {
                draw = pageindex,
                recordsTotal = list.Count(),
                recordsFiltered = list.Count(),
                data = list.OrderBy(m=>m.CreatedOn).Skip((pageindex - 1) * 10).Take(10)
            };

            if (Log.IsDebugEnabled)
                Log.Debug("获取菜单列表数据成功，当前页：" + pageindex);

            return Json(
                tableData
                , JsonRequestBehavior.AllowGet);
        }
    }
}