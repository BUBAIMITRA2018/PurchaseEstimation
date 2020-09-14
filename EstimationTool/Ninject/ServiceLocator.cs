using Estimationtool.ViewModels;
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

        private readonly IKernel kernel_1;
        private readonly IKernel kernel_2;

        public ServiceLocator()
        {
            kernel_1 = new StandardKernel(new ServiceModule());
            kernel_2 = new StandardKernel(new ServiceModule());
        }

        public HomeViewModel HomeViewModel
        {
            get { return kernel_1.Get<HomeViewModel>(); }
        }

        public LoginViewModel LoginViewModel
        {
            get { return kernel_1.Get<LoginViewModel>(); }
        }
    }
}
