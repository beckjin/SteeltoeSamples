using ClientHystrixService1.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClientHystrixService1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly BaseServiceCommand _baseServiceCommand;

        public ValuesController(BaseServiceCommand baseServiceCommand)
        {
            _baseServiceCommand = baseServiceCommand;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            return $"client hystrix {await _baseServiceCommand.GetValueAsync()}";
        }
    }
}
