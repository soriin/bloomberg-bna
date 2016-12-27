using System;
using System.Collections.Generic;

namespace bnaApi.data.repos
{
    public interface IExpenseRepository
    {
        IEnumerable<Expense> GetExpenses();
        Expense GetExpense(Guid id);
        void CreateExpense(Expense expense);
    }
}
