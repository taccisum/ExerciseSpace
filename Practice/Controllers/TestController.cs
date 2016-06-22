using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Factory;
using Model.Models;

namespace Practice.Controllers
{
    public class TestController : Controller
    {
        public ActionResult TestPost(string test, SysUser user, SysRole role)
        {
            var repositoryFactory =  new RepositoryFactory();
            repositoryFactory.Create<SysUser>();
            repositoryFactory.Create<SysUser>();
            repositoryFactory.Create<SysRole>();
            repositoryFactory.Create<SysRole>();
            repositoryFactory.Create<SysUser>();
            repositoryFactory.Create<SysUser>();


            return Json(new
            {
                Test1 = "Tac",
                Test2 = "Anit"
            }, JsonRequestBehavior.DenyGet);
        }


    }
}