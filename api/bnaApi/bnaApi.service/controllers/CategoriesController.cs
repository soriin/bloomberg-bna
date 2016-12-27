using bnaApi.data.repos;
using bnaApi.data.web;
using bnaApi.service.common;
using log4net;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace bnaApi.service.controllers
{
    public class CategoriesController : ApiController
    {
        private ILog _logger;
        private IKernel _container;
        private IUtilities _utilities;

        public CategoriesController()
        {
            _logger = LogManager.GetLogger(this.GetType().FullName);
            _container = bootstrapper.LoadKernel();
            _utilities = _container.Get<IUtilities>();
        }

        public HttpResponseMessage GetCategories()
        {
            _logger.Debug("GetCategories() Called.");

            HttpResponseMessage response;

            try
            {
                var categoryRepo = _container.Get<ICategoryRepository>();

                // Convert from a database object to one that is 1) easier to digest for the client and 2) stripped of any internal data we don't want out
                var categories = categoryRepo.GetCategories()
                    .OrderBy(x => x.name)
                    .Select(e => new CategoryWeb(e));
                response = _utilities.CreateHttpResponse(Request, HttpStatusCode.OK, categories);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response = _utilities.CreateHttpResponse(Request, HttpStatusCode.InternalServerError);
            }

            _logger.Debug("GetCategories() Exiting.");
            return response;
        }
    }
}
