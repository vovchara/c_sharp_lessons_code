namespace CSharpLess.Controller
{
    public interface IControllerFactory
    {
        ControllerBase Create<T>() where T : ControllerBase;
    }
}
