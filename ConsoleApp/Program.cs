using System;
using MyLibraryComponent;
using MyLibraryComponent.Log;
using MyLibraryComponent.LogicA;
using MyLibraryComponent.LogicB;
using MyLibraryComponent.LogicB.LogicC;
using MyLibraryComponent.LogicB.LogicC.LogicD;

namespace ConsoleApp
{
    class Program
    {
        private static void Main(string[] args)
        {

            //IMyLibrary myLibrary = ResolveLibraryNew();

            //IMyLibrary myLibrary = ResolveLibraryDefaultDependencyRosolver();

            //IMyLibrary myLibrary = ResolveLibraryUsingUnity();

            //IMyLibrary myLibrary = ResolveLibraryDefaultDependencyRosolverWithUnity();

            IMyLibrary myLibrary = ResolveUsingAnotherDependencyResolver();

            myLibrary.LibraryMethodA();
            myLibrary.LibraryMethodB();
            myLibrary.LibraryMethodC();

            Console.ReadKey();
        }

        private static IMyLibrary ResolveLibraryNew()
        {
            return new MyLibrary(
                new DefaultLogProvider(), new LogicB(
                    new DefaultLogProvider(),
                    new LogicC(new DefaultLogProvider(),
                        new LogicD(new DefaultLogProvider()))),
                        new LogicA(new DefaultLogProvider())
                        );
        }

        private static IMyLibrary ResolveLibraryDefaultDependencyRosolver()
        {
            var dependencyRosolver = new DefaultDependencyRosolver();           
            // You could use your own specific logger here...
            dependencyRosolver.LogProvider = new DefaultLogProvider();
            dependencyRosolver.ResolveDependencies();
            return dependencyRosolver.MyLibrary;
        }

        private static IMyLibrary ResolveLibraryDefaultDependencyRosolverWithUnity()
        {
            var dependencyRosolver = new DefaultDependencyRosolver();
            var container = UnityConfig.GetConfiguredContainer();
            dependencyRosolver.LogProvider = container.Resolve(typeof(ILogProvider), "") as ILogProvider;
            dependencyRosolver.ResolveDependencies();
            return dependencyRosolver.MyLibrary;
        }

        private static IMyLibrary ResolveLibraryUsingUnity()
        {
            var container = UnityConfig.GetConfiguredContainer();
            return container.Resolve(typeof(IMyLibrary), "") as IMyLibrary;
        }

        private static IMyLibrary ResolveUsingAnotherDependencyResolver()
        {
            AnotherDependencyResolver anotherDependencyResolver = new AnotherDependencyResolver();
            anotherDependencyResolver.Register<ILogProvider, DummyLogProvider>();
            return anotherDependencyResolver.Resolve<IMyLibrary>();
        }
    }
}
