using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Factory;
using HelperUnit.Extend;
using Model.Context;
using Model.Models;
using Practice.Unit;
using Practice.ViewModels;


namespace Practice.Controllers
{
    public class AccountController : Controller
    {
        private RepositoryFactory _repositoryFactory = new RepositoryFactory();


        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult Login()
        {
            ViewBag.LoginState = "登陆前";

            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection fc)
        {

            var uid = fc["uid"];
            string psd = fc["psd"];
            var user = _repositoryFactory.Create<SysUser>().Get(u => u.Uid == uid).FirstOrDefault();

            if (user != null)
            {
                if (psd.Equals(user.Psd))
                {
                    ViewBag.LoginState = uid + "已登陆, psd: " + user.Psd;
                }
                else
                {
                    ViewBag.LoginState = "登陆失败, " + uid + "不存在或密码错误";
                }
            
            }

            return View();
        }

        public ActionResult Register()
        {
            ViewBag.IsSubmit = 0;

            return View();
        }

        [HttpPost]
        public ActionResult Register(FormCollection fc)
        {
            ViewBag.IsSubmit = 1;

            string uid = fc["uid"];
            string psd = fc["psd"];
            string _psd = fc["psd_affirm"];

            if (psd != _psd)
            {
                ViewBag.Msg = "两次输入的密码不一致";
                return View();
            }

            var sysUser = _repositoryFactory.Create<SysUser>();
            var user = new SysUser()
            {
                Uid = uid,
                Psd = psd
            };
            sysUser.Insert(user);
            sysUser.Submit();

            ViewBag.Msg = "账号" + uid + " 密码" + psd + " ID: " + user.ID;
            return View();
        }


        public ActionResult ViewPage1()
        {
            return View();
        }

        public ActionResult Test()
        {
            var m = new TestModel()
            {
                Title = "Tac",
                SubTitle = "cisum",
                TestStr = "mvc layout page"
            };

            return View(m);
        }

        public ActionResult UE()
        {
            return View(new LayoutTestModel()
            {
                Title = "ueditor",
                SubTitle = "demo"
            });
        }
    }
}