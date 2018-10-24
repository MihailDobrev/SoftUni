namespace SIS.Framework.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using SIS.Framework.Services.Contracts;

    public class DependencyContainer : IDependencyContainer
    {
        private readonly IDictionary<Type, Type> dependencyDictionary;

        public DependencyContainer(IDictionary<Type, Type> dependencyDictionary)
        {
            this.dependencyDictionary = dependencyDictionary;
        }

        private Type this[Type key]
        {
            get => this.dependencyDictionary.ContainsKey(key) ? dependencyDictionary[key] : null;
            set => this.dependencyDictionary[key] = value;
        }
         
        public T CreateInstance<T>()
             => (T)this.CreateInstance(typeof(T));
     
        public object CreateInstance(Type type)
        {
            Type instanceType = this[type] ?? type;

            if (instanceType.IsInterface || instanceType.IsAbstract)
            {
                throw new InvalidOperationException($"Type {instanceType.FullName} cannot be instantiated");
            }

            ConstructorInfo constructor = instanceType
                .GetConstructors()
                .OrderByDescending(x => x.GetParameters().Length)
                .First();

            ParameterInfo[] constructorParameters = constructor.GetParameters();

            object[] constructorParameterObjects = new object[constructorParameters.Length];

            for (int i = 0; i < constructorParameters.Length; i++)
            {
                constructorParameterObjects[i] = this.CreateInstance(constructorParameters[i].ParameterType);
            }

            return constructor.Invoke(constructorParameterObjects);
        }

        public void RegisterDependancy<TSource, TDestination>()
        {
            this.dependencyDictionary[typeof(TSource)] = typeof(TDestination);
        }
    }
}
