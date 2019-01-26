using Steeltoe.CircuitBreaker.Hystrix;
using System.Threading.Tasks;

namespace ClientHystrix.Services.Commands
{
    public class GetValueCommand : HystrixCommand<string>
    {
        private readonly IBaseService _baseService;

        public GetValueCommand(IHystrixCommandOptions options,
            IBaseService baseService) : base(options)
        {
            _baseService = baseService;
            IsFallbackUserDefined = true;
        }

        public async Task<string> GetValueAsync()
        {
            return await ExecuteAsync();
        }

        protected override async Task<string> RunAsync()
        {
            var result = await _baseService.GetValueAsync();
            return result;
        }

        protected override async Task<string> RunFallbackAsync()
        {
            return await Task.FromResult("调用 GetValueAsync 接口异常，服务异常，请稍候再试");
        }
    }
}
