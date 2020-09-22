using System;
using System.Collections.Generic;
using Asgard_SDK.SDK.Services;
using Asgard_SDK.SDK.Services.Game;

namespace Asgard_SDK.SDK.Factories
{
    public class ServiceFactory
    {
        private static readonly Lazy<ServiceFactory> Lazy = new Lazy<ServiceFactory>( () => new ServiceFactory());

        public static ServiceFactory Instance => Lazy.Value;
        public static Action<bool> IsReady;
        
        private Dictionary<Type, IBaseService> _services;

        private NetworkService _networkService;
        
        private ServiceFactory()
        {
            
        }

        public void Init(Action<bool> onReady)
        {
            _networkService = new NetworkService();
            
            _networkService.Init(onConnected =>
            {
                _services = new Dictionary<Type, IBaseService>();
            
                _services.Add(typeof(LoginService),new LoginService().Init(ref _networkService));
                _services.Add(typeof(WorldService), new WorldService().Init(ref _networkService));
                _services.Add(typeof(SessionService), new SessionService().Init(ref _networkService));
                _services.Add(typeof(GameService), new GameService().Init(ref _networkService));
                
                onReady.Invoke(onConnected);
            });
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