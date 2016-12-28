using Autofac;

namespace Lemon.Web.OWIN.WebApiApp
{
    public interface IControllerRegister
    {
        void Register(ContainerBuilder builder);

    }
}