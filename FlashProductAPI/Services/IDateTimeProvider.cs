namespace FlashProductAPI_7.Services
{
    public interface IDateTimeProvider
    {
        public DateTimeOffset Now { get; }
    }
}
