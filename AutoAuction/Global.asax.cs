using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoAuction.Jobs;
using AutoAuction.Util;
using AutoAuction.WEB;
using AutoMapper;

namespace AutoAuction
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //DI
            AutofacConfig.ConfigureContainer();  
            //Automapper
            Mapper.Initialize(c=>c.AddProfile<MappingProfile>());
            // Quartz
            AuctionSheduler.Start();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
