using ClientHystrix.Services;
using ClientHystrix.Services.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientHystrix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly GetValueCommand _getValueCommand;
        private readonly GetValuesCommand _getValuesCommand;

        public ValuesController(GetValueCommand getValueCommand,
            GetValuesCommand getValuesCommand)
        {
            _getValueCommand = getValueCommand;
            _getValuesCommand = getValuesCommand;
        }

        [HttpGet("getvalue")]
        public async Task<string> GetValue()
        {
            return await _getValueCommand.GetValueAsync();
        }

        [HttpGet("getvalues")]
        public async Task<List<string>> GetValues()
        {
            return await _getValuesCommand.GetValuesAsync();
        }
    }
}
