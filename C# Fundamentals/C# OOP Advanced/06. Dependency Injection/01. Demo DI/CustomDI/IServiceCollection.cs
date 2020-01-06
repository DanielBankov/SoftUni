using System;

namespace CustomDI
{
    public interface IServiceCollection
    {
        void AddService<TImplementation, TClass>();

        TClass CreateInstance<TClass>();

        object CreateInstance(Type type);
    }
}
