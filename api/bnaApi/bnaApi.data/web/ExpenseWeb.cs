using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bnaApi.data.web
{
    public class ExpenseWeb
    {
        public System.DateTime dateExpensed { get; set; }
        public string description { get; set; }
        public double amount { get; set; }
        public System.Guid id { get; set; }

        public CategoryWeb category { get; set; }

        public ExpenseWeb() { }

        public ExpenseWeb(Expense expense)
        {
            dateExpensed = expense.dateExpensed;
            description = expense.description;
            amount = expense.amount;
            id = expense.id;

            category = new CategoryWeb(expense.Category);
        }
    }
}
