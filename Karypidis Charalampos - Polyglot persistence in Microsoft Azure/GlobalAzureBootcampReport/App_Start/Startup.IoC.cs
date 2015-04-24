using System;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using GlobalAzureBootcampReport.Azure;
using GlobalAzureBootcampReport.Controllers;
using GlobalAzureBootcampReport.Twitter;
using Owin;

namespace GlobalAzureBootcampReport
{
    public partial class Startup
    {
        public void ConfigureIoC(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof (HomeController).Assembly);

            builder.RegisterType<TwitterManager>().As<ITwitterManager>().SingleInstance();
            builder.RegisterType<TweetsRepository>().As<ITweetsRepository>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();
        }
        
    }
}