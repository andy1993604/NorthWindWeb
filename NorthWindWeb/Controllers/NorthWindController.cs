using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NorthWindWeb.Controllers
{
    [Authorize]
    public class NorthWindController : Controller
    {

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.UserName = ((FormsIdentity)User.Identity).Ticket.UserData;
            }
            base.OnActionExecuting(filterContext);
        }

    }

}