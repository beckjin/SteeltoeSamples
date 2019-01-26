using Steeltoe.CircuitBreaker.Hystrix;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientHystrix.Services.Commands
{
    public class GetValuesCommand : HystrixCommand<List<string>>
    {
        private readonly IBaseService _baseService;

        public GetValuesCommand(IHystrixCommandOptions options,
            IBaseService baseService) : base(options)
        {
            _baseService = baseService;
            IsFallbackUserDefined = true;
        }

        public async Task<List<string>> GetValuesAsync()
        {
            return await ExecuteAsync();
        }

        protected override async Task<List<string>> RunAsync()
        {
            var result = await _baseService.GetValuesAsync();
            return result;
        }
        protected override async Task<List<string>> RunFallbackAsync()
        {
            return await Task.FromResult(new List<string> { "调用 GetValuesAsync 接口异常，服务异常，请稍候再试" });
        }

    }
}
