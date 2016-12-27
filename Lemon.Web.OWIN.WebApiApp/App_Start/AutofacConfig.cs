using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;

namespace Lemon.Web.OWIN.WebApiApp
{
    /// <summary>
    /// Autofac配置
    /// </summary>
    public static class AutofacConfig
    {
        /// <summary>
        ///注册Api组件
        /// </summary>
        public static IContainer Container;

        /// <summary>
        /// Initializes and configures instance of <see cref="IContainer"/>.
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="controllerAssemblies"></param>
        public static void Configure(HttpConfiguration configuration, params Assembly[] controllerAssemblies)
        {
            var builder = new ContainerBuilder();
            //api注册
            builder.RegisterApiControllers(Assembly.Load("Lemon.Web.DemoController"));
            //其他组件注册
            //builder.(Assembly.Load("Lemon.Web.DemoController"));



            //更新容器
            Container = builder.Build();
            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(Container);
        }
    }
}