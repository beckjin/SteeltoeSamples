using Microsoft.AspNetCore.Mvc;

namespace BaseService2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "BaseService2";
        }
    }
}
