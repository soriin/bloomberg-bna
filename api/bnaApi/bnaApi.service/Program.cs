using Microsoft.Owin.Hosting;
using System;
using System.ServiceProcess;
using log4net;
using log4net.Config;

namespace bnaApi.service
{
    public static class ApiService
    {
        #region Copied code
        // I've done this many times in the past but couldn't remember everything to set so I got the block from SO.
        // http://stackoverflow.com/questions/7764088/net-console-application-as-windows-service
        // Added the private bits myself
        public const string ServiceName = "BNA API Service";
        private static IDisposable _httpServer;
        private static ILog _logger;

        public class Service : ServiceBase
        {
            public Service()
            {
                ServiceName = ApiService.ServiceName;
            }

            protected override void OnStart(string[] args)
            {
                ApiService.Start(args);
            }

            protected override void OnStop()
            {
                ApiService.Stop();
            }
        }

        static void Main(string[] args)
        {
            if (!Environment.UserInteractive)
                // running as service
                using (var service = new Service())
                    ServiceBase.Run(service);
            else
            {
                // running as console app
                Start(args);

                Console.WriteLine("Press any key to stop...");
                Console.ReadKey(true);

                Stop();
            }
        }
        #endregion

        private static void Start(string[] args)
        {
            _logger = LogManager.GetLogger(typeof(ApiService));
            XmlConfigurator.Configure();

            string baseUrl = "http://localhost:9901";
            _logger.Info($"Starting server at {baseUrl}");

            _httpServer = WebApp.Start<WebApiStartup>(baseUrl);
            
            _logger.Info("Server running...");
        }

        private static void Stop()
        {
            _logger.Info("Server shutting down...");
            _httpServer.Dispose();
            _logger.Info("Server shut down.");
        }
    }
}
