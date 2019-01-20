using Steeltoe.CircuitBreaker.Hystrix;
using System.Threading.Tasks;

namespace ClientHystrixService1.Services
{
    public class BaseServiceCommand : HystrixCommand<string>
    {
        private readonly IBaseService _baseService;

        public BaseServiceCommand(IHystrixCommandOptions options, 
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
            return await Task.FromResult("Sorry, the service is unavaliable now. Please try again later.");
        }
    }
}
