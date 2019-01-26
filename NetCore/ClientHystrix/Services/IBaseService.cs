using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientHystrix.Services
{
    public interface IBaseService
    {
        Task<string> GetValueAsync();

        Task<List<string>> GetValuesAsync();
    }
}
