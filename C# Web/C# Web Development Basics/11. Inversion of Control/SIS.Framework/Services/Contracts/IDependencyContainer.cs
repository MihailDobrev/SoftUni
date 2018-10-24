namespace SIS.Framework.Services.Contracts
{
    using System;

    public interface IDependencyContainer
    {
        void RegisterDependancy<TSource, TDestination>();

        TType CreateInstance<TType>();

        object CreateInstance(Type type);
    }
}
