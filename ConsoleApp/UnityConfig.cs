using System;
using Microsoft.Practices.Unity;
using MyLibraryComponent;
using MyLibraryComponent.Log;
using MyLibraryComponent.LogicA;
using MyLibraryComponent.LogicB;
using MyLibraryComponent.LogicB.LogicC;
using MyLibraryComponent.LogicB.LogicC.LogicD;

namespace ConsoleApp
{
    class UnityConfig
    {
        #region Unity Container

        private static readonly Lazy<IUnityContainer> Container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static IUnityContainer GetConfiguredContainer()
        {
            return Container.Value;
        }

        #endregion

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType(typeof(ILogProvider), typeof(DefaultLogProvider), new TransientLifetimeManager());
            container.RegisterType(typeof(ILogicA), typeof(LogicA), new TransientLifetimeManager());
            container.RegisterType(typeof(ILogicB), typeof(LogicB), new TransientLifetimeManager());
            container.RegisterType(typeof(ILogicC), typeof(LogicC), new TransientLifetimeManager());
            container.RegisterType(typeof(ILogicD), typeof(LogicD), new TransientLifetimeManager());
            container.RegisterType(typeof(IMyLibrary), typeof(MyLibrary), new TransientLifetimeManager());
        }
    }
}
