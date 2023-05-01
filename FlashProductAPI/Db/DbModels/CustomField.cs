namespace FlashProductAPI_7.Db.DbModels
{
    public class CustomField
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }
        public virtual ICollection<CustomFieldValueWrapper>? Values { get; set; }
    }
}