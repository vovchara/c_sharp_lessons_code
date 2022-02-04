using System.Threading.Tasks;

namespace ShopModel.Model
{
    public interface IUserCredentialsService
    {
        Task<bool> TryLogin(string login, string password);
    }
}
