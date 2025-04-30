using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;


namespace FinanceTrackerTemplate.DependencyInjection
{
    public class SimpleServiceCollection : IServiceCollection
    {
        private readonly Dictionary<Type, Type> _scoped = new();
        private readonly Dictionary<Type, Type> _singleton = new();
        private readonly Dictionary<Type, object> _singletonInstances = new();
        private readonly Dictionary<Type, object> _scopedInstances = new();

        public void AddScoped<TInterface, TImplementation>() where TImplementation : TInterface
        {
            _scoped[typeof(TInterface)] = typeof(TImplementation);
        }

        public void AddSingleton<TInterface, TImplementation>() where TImplementation : TInterface
        {
            _singleton[typeof(TInterface)] = typeof(TImplementation);
        }

        public void AddTransient<T>() where T : class
        {
            _scoped[typeof(T)] = typeof(T);
        }

        public object CreateInstance(Type type)
        {
            var ctor = type.GetConstructors().First();
            var parameters = ctor.GetParameters()
                .Select(p => GetService(p.ParameterType))
                .ToArray();
            return Activator.CreateInstance(type, parameters)!;
        }

        public TInterface GetService<TInterface>()
        {
            return (TInterface)GetService(typeof(TInterface));
        }

        public object GetService(Type type)
        {
            if (_singletonInstances.TryGetValue(type, out var singletonInstance))
                return singletonInstance;

            if (_singleton.TryGetValue(type, out var singletonImpl))
            {
                var instance = CreateInstance(singletonImpl);
                _singletonInstances[type] = instance;
                return instance;
            }

            if (_scopedInstances.TryGetValue(type, out var scopedInstance))
                return scopedInstance;

            if (_scoped.TryGetValue(type, out var scopedImpl))
            {
                var instance = CreateInstance(scopedImpl);
                _scopedInstances[type] = instance;
                return instance;
            }

            if (type.IsClass)
            {
                var instance = CreateInstance(type);
                return instance;
            }

            throw new Exception($"Service {type.Name} is not registered.");
        }

        public IServiceProvider BuildServiceProvider()
        {
            return new SimpleServiceProvider(this);
        }
    }

    public class SimpleServiceProvider : IServiceProvider
    {
        private readonly SimpleServiceCollection _services;

        public SimpleServiceProvider(SimpleServiceCollection services)
        {
            _services = services;
        }

        public object GetService(Type serviceType)
        {
            return _services.GetService(serviceType);
        }

        public T GetRequiredService<T>() => (T)GetService(typeof(T));
    }
}
