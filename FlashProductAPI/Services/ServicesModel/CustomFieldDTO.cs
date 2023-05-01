namespace FlashProductAPI_7.Services.ServicesModel
{
    public class CustomFieldDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int ProductId { get; set; }
        public virtual ICollection<CustomFieldValueWrapperDTO>? Values { get; set; }

    }
}