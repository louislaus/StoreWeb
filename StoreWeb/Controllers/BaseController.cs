using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace StoreWeb.Controllers
{
    public class BaseController : Controller
    {
        protected bool IsLogined { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity as FormsIdentity;
            }
            ViewRecord(requestContext);
        }
        void ViewRecord(RequestContext _context)
        {
            try
            {

            }catch(Exception ex)
            {
            }
        }
    }
}