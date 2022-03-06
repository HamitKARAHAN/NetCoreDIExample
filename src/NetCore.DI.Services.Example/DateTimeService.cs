using Microsoft.Extensions.Logging;

namespace NetCore.DI.Services.Example
{
    public class DateTimeService : ISingletonDateService, IScopedDateService, ITransientDateService
    {
        private readonly ILogger<DateTimeService> _logger;
        public DateTimeService(ILogger<DateTimeService> logger)
        {
            _logger=logger;
            _logger.LogInformation("DateTime Service is running...");
        }
        public Task<TimeSpan> GetDateTime { get; init; } = Task.FromResult(DateTime.Now.TimeOfDay);
    }
}
