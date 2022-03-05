namespace NetCore.DI.Services.Example
{
    public interface IDateService
    {
        public Task<TimeSpan> GetDateTime { get; init; }
    }

    public interface ISingletonDateService : IDateService { }

    public interface IScopedDateService : IDateService { }

    public interface ITransientDateService : IDateService { }
}
