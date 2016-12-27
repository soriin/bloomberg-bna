using bnaApi.data;
using bnaApi.data.repos;
using bnaApi.data.web;
using bnaApi.service.common;
using log4net;
using Ninject;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace bnaApi.service.controllers
{
    public class ExpensesController : ApiController
    {
        private ILog _logger;
        private IKernel _container;
        private IUtilities _utilities;

        public ExpensesController()
        {
            _logger = LogManager.GetLogger(this.GetType().FullName);
            _container = bootstrapper.LoadKernel();
            _utilities = _container.Get<IUtilities>();
        }

        public HttpResponseMessage GetExpenses()
        {
            _logger.Debug("GetExpenses() Called.");

            HttpResponseMessage response;

            try
            {
                var expenseRepo = _container.Get<IExpenseRepository>();

                // Convert from a database object to one that is 1) easier to digest for the client and 2) stripped of any internal data we don't want out
                var expenses = expenseRepo.GetExpenses()
                    .OrderBy(x => x.dateExpensed)
                    .Select(e => new ExpenseWeb(e));
                response = _utilities.CreateHttpResponse(Request, HttpStatusCode.OK, expenses);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response = _utilities.CreateHttpResponse(Request, HttpStatusCode.InternalServerError);
            }

            _logger.Debug("GetExpenses() Exiting.");
            return response;
        }

        public HttpResponseMessage GetExpense(string id)
        {
            _logger.Debug($"GetExpense(string id: {id}) Called.");

            HttpResponseMessage response;
            try
            {
                var expenseRepo = _container.Get<IExpenseRepository>();

                var dbExpense = expenseRepo.GetExpense(new Guid(id));

                if (dbExpense != null)
                {
                    var result = new ExpenseWeb(dbExpense);
                    response = _utilities.CreateHttpResponse(Request, HttpStatusCode.OK, result);
                }
                else
                {
                    response = _utilities.CreateHttpResponse(Request, HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response = _utilities.CreateHttpResponse(Request, HttpStatusCode.InternalServerError);
            }

            _logger.Debug($"GetExpense(string id: {id}) Exiting.");
            return response;
        }

        public HttpResponseMessage PostExpense(ExpenseWeb expense)
        {
            _logger.Debug($"PostExpense(ExpenseWeb expense) Called.");

            HttpResponseMessage response;
            try
            {
                var expenseRepo = _container.Get<IExpenseRepository>();

                // Do server side validation here before saving to DB...one day.

                var newExpense = new Expense()
                {
                    id = Guid.NewGuid(),
                    dateCreated = System.DateTime.UtcNow,
                    dateExpensed = expense.dateExpensed,
                    amount = expense.amount,
                    description = expense.description,
                    categoryId = expense.category.id
                };

                expenseRepo.CreateExpense(newExpense);

                response = _utilities.CreateHttpResponse(Request, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response = _utilities.CreateHttpResponse(Request, HttpStatusCode.InternalServerError);
            }

            _logger.Debug($"PostExpense(ExpenseWeb expense) Exiting.");
            return response;
        }
    }
}
