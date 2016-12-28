using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;
using Lemon.Web.OWIN.WebApiApp;

namespace Lemon.Web.TestController
{
    public class ControllerLoader : IControllerRegister
    {
        public void Register(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
        }
    }
}