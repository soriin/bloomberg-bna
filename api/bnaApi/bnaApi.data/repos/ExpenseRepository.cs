using log4net;
using System;
using System.Collections.Generic;
using System.Linq;

namespace bnaApi.data.repos
{
    public class ExpenseRepository : IExpenseRepository
    {
        private static ILog _logger;
        private bloombergEntities _context;

        public ExpenseRepository(bloombergEntities context)
        {
            _logger = LogManager.GetLogger(this.GetType().FullName);
            _context = context;
        }

        public void CreateExpense(Expense expense)
        {
            _context.Expenses.Add(expense);
            _context.SaveChanges();
        }

        public Expense GetExpense(Guid id)
        {
            return _context.Expenses.FirstOrDefault(e => e.id == id);
        }

        public IEnumerable<Expense> GetExpenses()
        {
            return _context.Expenses;
        }
    }
}
