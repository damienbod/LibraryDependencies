using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MyLibraryComponent.Log;
using MyLibraryComponent.LogicA;
using MyLibraryComponent.LogicB;
using MyLibraryComponent.LogicB.LogicC;
using MyLibraryComponent.LogicB.LogicC.LogicD;

namespace MyLibraryComponent
{
    public class AnotherDependencyResolver
    {
        public AnotherDependencyResolver()
        {
            RegisterDefaultTypes();
        }

        private readonly Dictionary<Type, Type> _dependencies =  new Dictionary<Type, Type>();

        public T Resolve<T>()
        {
            return (T) Resolve(typeof (T));
        }

        public void Register<TFrom, TTo>()
        {
            if (_dependencies.ContainsKey(typeof (TFrom)))
            {
                _dependencies.Remove(typeof (TFrom));
            }

            _dependencies.Add(typeof (TFrom), typeof (TTo));
        }

        private object Resolve(Type type)
        {
            Type resolvedType = LookUpDependency(type);
            ConstructorInfo constructor =  resolvedType.GetConstructors().First();
            ParameterInfo[] parameters = constructor.GetParameters();

            if (!parameters.Any())
            {
                return Activator.CreateInstance(resolvedType);
            }

            return constructor.Invoke(  ResolveParameters(parameters).ToArray());
        }

        private Type LookUpDependency(Type type)
        {
            return _dependencies[type];
        }

        private IEnumerable<object> ResolveParameters(IEnumerable<ParameterInfo> parameters)
        {
            return parameters.Select(p => Resolve(p.ParameterType)).ToList();
        }

        private void RegisterDefaultTypes()
        {
            Register<ILogProvider, DefaultLogProvider>();
            Register<ILogicA, LogicA.LogicA>();
            Register<ILogicB, LogicB.LogicB>();
            Register<ILogicC, LogicC>();
            Register<ILogicD, LogicD>();
            Register<IMyLibrary, MyLibrary>();
        }
    }
}
