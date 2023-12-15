using Api.Interface.IService;

namespace Api.Service.TimeProvider
{
    public class DateTimeService : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
