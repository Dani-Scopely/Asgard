using System;
using System.Collections.Generic;
using Asgard_SDK.SDK.Services;

namespace Asgard_SDK.SDK.Factories
{
    public class ServiceFactory
    {
        private static readonly Lazy<ServiceFactory> Lazy = new Lazy<ServiceFactory>( () => new ServiceFactory());

        public static ServiceFactory Instance => Lazy.Value;

        private readonly Dictionary<Type, IBaseService> _services;

        private NetworkService _networkService;
        
        private ServiceFactory()
        {
            _networkService = new NetworkService();
            
            Init();
            
            _services = new Dictionary<Type, IBaseService>();
            
            _services.Add(typeof(LoginService),new LoginService().Init(ref _networkService));
            _services.Add(typeof(WorldService), new WorldService().Init(ref _networkService));
        }

        public T Get<T>() where  T : class
        {
            var t = typeof(T);

            if (!_services.ContainsKey(t)) throw new Exception("Invalid or inactive service.");
            
            var serviceInstance = _services[t];
            
            return serviceInstance as T;
        }

        private void Init()
        {
            _networkService.Init();
        }
    }
}