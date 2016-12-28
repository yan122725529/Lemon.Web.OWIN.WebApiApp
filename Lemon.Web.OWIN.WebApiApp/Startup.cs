using System.Configuration;
using System.Reflection;
using System.Web.Http;
using Microsoft.Owin;
using Owin;
using Lemon.Web.OWIN.WebApiApp.App_Start;

[assembly: OwinStartup(typeof(Lemon.Web.OWIN.WebApiApp.Startup))]

namespace Lemon.Web.OWIN.WebApiApp
{
    /// <summary>
    /// Represents the entry point into an application.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Specifies how the ASP.NET application will respond to individual HTTP request.
        /// </summary>
        /// <param name="app">Instance of <see cref="IAppBuilder"/>.</param>
        public void Configuration(IAppBuilder app)
        {
            //CorsConfig.ConfigureCors(ConfigurationManager.AppSettings["cors"]);
            //app.UseCors(CorsConfig.Options);
            var configuration = new HttpConfiguration();
            //Assembly.GetExecutingAssembly(), 
            //, Assembly.Load("Lemon.Web.TestController")

          
            AutofacConfig.Configure(configuration, Assembly.Load("Lemon.Web.DemoController"), Assembly.Load("Lemon.Web.TestController"),Assembly.GetExecutingAssembly());
            app.UseAutofacMiddleware(AutofacConfig.Container);
            FormatterConfig.Configure(configuration);
            RouteConfig.Configure(configuration);
            ServiceConfig.Configure(configuration);
            app.UseWebApi(configuration);
        }
    }
}