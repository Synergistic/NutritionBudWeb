using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Moq;
using Ninject;
using NutritionWeb.Domain.Abstract;
using NutritionWeb.Domain.Concrete;
using NutritionWeb.Domain.Entities;
using NutritionWeb.Domain.Calculators;

namespace NutritionWeb.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IMifflin>().To<MifflinCalculator>();
            kernel.Bind<IPenn>().To<PennCalculator>();
            kernel.Bind<IFluid>().To<FluidCalculator>();
            kernel.Bind<IBodyMassIndex>().To<BMICalculator>();
            kernel.Bind<IIdealBodyWeight>().To<IBWCalculator>();
            kernel.Bind<IUsualBodyWeight>().To<UBWCalculator>();
            kernel.Bind<INutritionCalculator>().To<NutritionCalculator>();
        }
    }
}