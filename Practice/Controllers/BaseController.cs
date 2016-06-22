using System;
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
using Model.Models;
using GlobalContext = Global.Configs.GlobalContext;

namespace Practice.Controllers
{
    public abstract class BaseController : Controller
    {
        protected RepositoryFactory RepositoryFactory = new RepositoryFactory();
        protected ILog Log;

        protected SysUser CurrentUser
        {
            get
            {
                var userId = CookiesHelper.Get(GlobalContext.CURRENT_USER).ToGuid();
                return
                    RepositoryFactory.Create<SysUser>().Get(u => u.ID == userId).FirstOrDefault();
            }
        }


        protected BaseController()
        {
            Log = Log4NetHelper.GetLogger("Controller." + this.GetType().Name);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (CurrentUser == null)
            {
                if (filterContext.ActionDescriptor.ControllerDescriptor.ControllerName == "User")
                {
                    CookiesHelper.Remove(GlobalContext.CURRENT_USER);
                }
                else
                {
                    filterContext.Result = new RedirectToRouteResult("Default",
                        new RouteValueDictionary(new {controller = "User", action = "Login"}));
                }
            }
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            Log.Error("调用API的过程中发生了未经处理的异常", filterContext.Exception);

        }
    }
}