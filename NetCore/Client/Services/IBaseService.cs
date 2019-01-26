using System.Threading.Tasks;

namespace Client.Services
{
    public interface IBaseService
    {
        Task<string> GetValueAsync();
    }
}
