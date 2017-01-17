using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using AutoAuction.DAL.EFContext;
using AutoAuction.DAL.Interfaces;
using AutoAuction.DAL.Repositories;
using AutoAuction.Providers;
using Autofac;
using Autofac.Extras.Quartz;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Quartz;
using Quartz.Impl;

namespace AutoAuction.Util
{
    public class AutofacConfig
    {       
        public static void ConfigureContainer()
        {
            // получаем экземпляр контейнера
            var builder = new ContainerBuilder();
            // регистрируем контроллер в текущей сборке
            //MVC controller
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            //WebApi controller
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            // регистрируем споставление типов 
            builder.RegisterType<EFUnitOfWork>().As<IUnitofWork>().
                WithParameter(new TypedParameter(typeof(AuctionContext),
                    new AuctionContext("name=DefaultConnection")));
            builder.RegisterType<CustomerRoleProvider>();        
            // создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();
            // установка сопоставителя зависимостей   MVC
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            // установка сопоставителя зависимостей   WebApi
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}