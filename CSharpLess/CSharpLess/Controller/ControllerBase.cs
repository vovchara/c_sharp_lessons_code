using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLess.Controller
{
    public abstract class ControllerBase : IDisposable
    {
        public abstract Task Run();
        public abstract void Dispose();
    }
}
