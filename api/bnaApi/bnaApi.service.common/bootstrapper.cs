using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace bnaApi.service.common
{
    public static class bootstrapper
    {
        public static IKernel LoadKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load("bnaApi.*.dll");
            return kernel;
        }
    }
}
