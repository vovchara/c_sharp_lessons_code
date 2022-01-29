using System;
using System.Threading.Tasks;

namespace CSharpLess.Controller
{
    public abstract class ControllerBase : IDisposable
    {
        public abstract void Dispose();

        public abstract Task Run();

    }
}
