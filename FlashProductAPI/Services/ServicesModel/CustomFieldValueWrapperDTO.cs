namespace FlashProductAPI_7.Services.ServicesModel
{
    public class CustomFieldValueWrapperDTO
    {
        public int Id { get; set; }
        public string? Key { get; set; }
        public string? Value { get; set; }
        public int CustomFieldId { get; set; }
    }
}