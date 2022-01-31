using System;

namespace CSharpLess.Controller
{
    public class ControllerFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ControllerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T Create<T>() where T : ControllerBase
        {
            var controller = _serviceProvider.GetService(typeof(T));
            return (T)controller;
        }
    }
}
