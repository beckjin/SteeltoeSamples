using Microsoft.AspNetCore.Mvc;

namespace BaseService1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "BaseService1";
        }
    }
}
