using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Factory;
using log4net;
using Model.Entity;
using Model.Models;
using Practice.Controllers.Attributes;
using Practice.ViewModels;


namespace Practice.Controllers
{
    public class JQDataTablesTrailController : BaseController
    {
        public ActionResult Index()
        {
            if (Log.IsInfoEnabled)
                Log.Info("获取默认视图");

            ViewBag.Title = "jQuery Datatables - trial";
            return View();
        }

        public ActionResult GetUserList(int pageindex)
        {
            if (Log.IsInfoEnabled)
                Log.Info("获取用户列表",new ApplicationException("hahaha"));


            var users = RepositoryFactory.At<SysUser>();
            var list = users.Get(u => true).Select(u=>new
            {
                u.ID,
                UserName = u.Uid,
                Password = u.Psd,
            });

            var tableData = new
            {
                draw = pageindex,
                recordsTotal = list.Count(),
                recordsFiltered = list.Count(),
                data = list.OrderBy(u => u.UserName).Skip((pageindex - 1) * 10).Take(10)
            };

            if (Log.IsDebugEnabled)
                Log.Debug("获取列表数据成功，当前页：" + pageindex);
            //以下命名属性也可以
            //var tableData = new
            //{
            //    sEcho = pageindex,
            //    iTotalRecords = list.Count(),
            //    iTotalDisplayRecords = list.Count(),
            //    aaData = list.OrderBy(u => u.UserName).Skip((pageindex - 1) * 10).Take(10)
            //};

            return Json(
                tableData
                , JsonRequestBehavior.AllowGet);
        }
    }
}