using bnaApi.data.repos;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bnaApi.data
{
    public class DataNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<bloombergEntities>().ToSelf();
            Bind<IExpenseRepository>().To<ExpenseRepository>();
            Bind<ICategoryRepository>().To<CategoryRepository>();
        }
    }
}
