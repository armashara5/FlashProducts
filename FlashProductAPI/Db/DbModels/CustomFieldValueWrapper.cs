namespace FlashProductAPI_7.Db.DbModels
{
    public class CustomFieldValueWrapper
    {
        public int Id { get; set; }
        public string? Key { get; set; }
        public string? Value { get; set; }
        public int CustomFieldId { get; set; }
        public virtual CustomField? CustomField { get; set; }
    }
}