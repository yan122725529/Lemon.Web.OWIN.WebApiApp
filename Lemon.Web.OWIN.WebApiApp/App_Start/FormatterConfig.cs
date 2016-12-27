using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace Lemon.Web.OWIN.WebApiApp.App_Start
{
    /// <summary>
    /// Represents formatter configuration.
    /// </summary>
    public static class FormatterConfig
    {
        /// <summary>
        /// 配置Formatter
        /// </summary>
        /// <param name="configuration"></param>
        public static void Configure(HttpConfiguration configuration)
        {
            configuration.Formatters.Remove(configuration.Formatters.XmlFormatter);

            configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();

            configuration.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;
        }
    }
}