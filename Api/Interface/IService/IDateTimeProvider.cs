namespace Api.Interface.IService
{
    public interface IDateTimeProvider
    {
        public DateTime UtcNow { get; }
    }
}
