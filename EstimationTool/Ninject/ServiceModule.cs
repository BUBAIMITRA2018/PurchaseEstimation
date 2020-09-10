using Estimationtool.Models;
using Estimationtool.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstimationTool.Ninject
{
    class ServiceModule : NinjectModule
    {

        public override void Load()
        {
            Bind<IDataStore<Product>>().To<MockDataStore>();

        }
    }
}
