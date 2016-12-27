using log4net;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace bnaApi.service
{
    public class WebApiStartup
    {
        private static ILog _logger;

        public WebApiStartup()
        {
            _logger = LogManager.GetLogger(this.GetType().FullName);
        }

        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            
            // Setup routes
            // There aren't any attribute routes used here but in a real system I would almost defintely have some.
            //config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("Api", "{controller}/{id}", new { id = RouteParameter.Optional });

            appBuilder.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            appBuilder.UseWebApi(config);
        }
    }
}
