using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using T_Ninject.Data;

namespace T_Ninject
{
    public class NinjectIoc : IDependencyResolver
    {
        private IKernel Kernel;
        public NinjectIoc()
        {
            Kernel = new StandardKernel();
            AddBindings();
        }

        private void AddBindings()
        {
            Kernel.Bind<IRepository>().To<Fake2Repository>();
            //Kernel.Bind<IA>().To<A1>();
        }

        public object GetService(Type serviceType)
        {
            return Kernel.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Kernel.GetAll(serviceType);
        }
    }
}