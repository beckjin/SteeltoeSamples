using System.Threading.Tasks;

namespace ClientHystrixService1.Services
{
    public interface IBaseService
    {
        Task<string> GetValueAsync();
    }
}
