using System;
using System.Collections.Generic;
using Asgard_SDK.SDK.Services;
using Asgard_SDK.SDK.Services.Login;
using Asgard_SDK.SDK.Services.Network;

namespace Asgard_SDK.SDK.Factories
{
    public sealed class ServiceFactory
    {
        private static readonly Lazy<ServiceFactory> Lazy = new Lazy<ServiceFactory>( () => new ServiceFactory());

        public static ServiceFactory Instance => Lazy.Value;

        private readonly Dictionary<Type, IBaseService> _services;
        
        private ServiceFactory()
        {
            _services = new Dictionary<Type, IBaseService>();
            
            _services.Add(typeof(LoginService),new LoginService());
            _services.Add(typeof(NetworkService), new NetworkService());
        }

        public T Get<T>() where  T : class
        {
            var t = typeof(T);

            if (!_services.ContainsKey(t)) throw new Exception("Invalid or inactive service.");
            
            var serviceInstance = _services[t];
            return serviceInstance as T;
        }
    }
}