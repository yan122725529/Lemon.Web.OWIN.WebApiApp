using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;

namespace Lemon.Web.OWIN.WebApiApp
{
    /// <summary>
    ///     Autofac配置
    /// </summary>
    public static class AutofacConfig
    {
        /// <summary>
        ///     注册Api组件
        /// </summary>
        public static IContainer Container;

      

        /// <summary>
        ///     Initializes and configures instance of <see cref="IContainer" />.
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="controllerAssemblies"></param>
        public static void Configure(HttpConfiguration configuration, params Assembly[] controllerAssemblies)
        {
            var typeList = new List<Type>();
          var   builder = new ContainerBuilder();
            //api注册
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            #region 测试插件controller

            var demoassembly = Assembly.Load("Lemon.Web.DemoController");
            var testassembly = Assembly.Load("Lemon.Web.TestController");
            var demo = demoassembly.GetTypes().FirstOrDefault(x => x.Name == "IControllerRegister");
            var test = testassembly.GetTypes().FirstOrDefault(x => x.Name == "IControllerRegister");

            if (demo != null)
                typeList.Add(demo);
            if (test != null)
                typeList.Add(test);


            foreach (var type in typeList)
            {
                var instance=   (IControllerRegister)Activator.CreateInstance(type);
                instance?.Register(builder);
            }
            #endregion

            //其他组件注册
            //builder.(Assembly.Load("Lemon.Web.DemoController"));


            //更新容器
            Container = builder.Build();
            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(Container);
        }
    }
}