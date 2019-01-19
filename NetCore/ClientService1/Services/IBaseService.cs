using System.Threading.Tasks;

namespace ClientService1.Services
{
    public interface IBaseService
    {
        Task<string> GetValueAsync();
    }
}
