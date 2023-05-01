namespace FlashProductAPI_7.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTimeOffset Now { get => DateTime.Now; }
    }
}
