using ClientService1.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClientService1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IBaseService _baseService;

        public ValuesController(IBaseService baseService)
        {
            _baseService = baseService;
        }

        // GET api/values
        [HttpGet]
        public async Task<string> Get()
        {
            return $"client { await _baseService.GetValueAsync()}";
        }
    }
}
