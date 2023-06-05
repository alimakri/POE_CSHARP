using System.Collections.Generic;
using System.Collections;
using System;

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
        Kernel.Bind<ArrayList>().ToSelf().InSingletonScope();
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
