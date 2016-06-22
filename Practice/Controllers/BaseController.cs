using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Factory;
using HelperUnit.Log;
using log4net;

namespace Practice.Controllers
{
    public class BaseController : Controller
    {
        protected RepositoryFactory RepositoryFactory = new RepositoryFactory();
        protected ILog Log = Log4NetHelper.GetLogger("Practice.Controllers.JQDataTablesTrail");


        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
    }
}