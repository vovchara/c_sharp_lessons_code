using System;

namespace CSharpLess.Controller
{
    public class ControllerFactory : IControllerFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ControllerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ControllerBase Create<T>() where T : ControllerBase
        {
            return _serviceProvider.GetService(typeof(T)) as ControllerBase;
        }
    }
}
