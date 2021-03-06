﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Factory;
using HelperUnit.Extend;
using HelperUnit.Units;
using HelperUnit.Units.Log;
using log4net;
using Model.Entity;
using GlobalContext = Global.Configs.GlobalContext;

namespace Practice.Controllers
{
    public abstract class BaseController : Controller
    {
        protected RepositoryFactory RepositoryFactory = new RepositoryFactory();
        protected ILog Log;


        protected static SysUser CurrentUser
        {
            get
            {
                var userId = CookiesHelper.Get(GlobalContext.CURRENT_USER).ToGuid();
                return new RepositoryFactory().At<SysUser>().Get(u => u.ID == userId).FirstOrDefault();
            }
        }


        protected BaseController()
        {
            Log = Log4NetHelper.GetLogger("Controller." + this.GetType().Name);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (filterContext.ActionDescriptor.ControllerDescriptor.ControllerName == "User" &&
                filterContext.ActionDescriptor.ActionName == "Login" && CurrentUser != null)
            {
                CookiesHelper.Remove(GlobalContext.CURRENT_USER);
                CookiesHelper.Remove(GlobalContext.AUTOLOGIN);
            }
            else if (CurrentUser == null && !(
                filterContext.ActionDescriptor.ControllerDescriptor.ControllerName == "User" &&
                (filterContext.ActionDescriptor.ActionName == "Verify" || filterContext.ActionDescriptor.ActionName == "Login")
                ))
            {
                filterContext.Result = new RedirectToRouteResult("Default",
                    new RouteValueDictionary(new {controller = "User", action = "Login"}));
            }
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            Log.Error("调用API的过程中发生了未经处理的异常", filterContext.Exception);
        }
    }
}