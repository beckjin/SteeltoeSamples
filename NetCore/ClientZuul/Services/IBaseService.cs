using System.Threading.Tasks;

namespace ClientZuul.Services
{
    public interface IBaseService
    {
        Task<string> GetValueAsync();
    }
}
