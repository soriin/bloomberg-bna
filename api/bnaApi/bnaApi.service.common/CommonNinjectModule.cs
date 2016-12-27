using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bnaApi.service.common
{
    public class CommonNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUtilities>().To<Utilities>();
        }
    }
}
