namespace FlashProductAPI_7.Services.ServicesModel
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<ProductDTO>? Products { get; set; }
    }
}
