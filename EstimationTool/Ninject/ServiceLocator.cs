using EstimationTool.ViewModel;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstimationTool.Ninject
{
  public  class ServiceLocator
    {

        private readonly IKernel kernel;

        public ServiceLocator()
        {
            kernel = new StandardKernel(new ServiceModule());
        }

        public HomeViewModel HomeViewModel
        {
            get { return kernel.Get<HomeViewModel>(); }
        }
    }
}
