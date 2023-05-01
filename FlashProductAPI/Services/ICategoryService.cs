using FlashProductAPI_7.Services.ServicesModel;

namespace FlashProductAPI_7.Services
{
    public interface ICategoryService
    {
        Task<CategoryDTO?> DeleteCategory(int id);
        Task<CategoryDTO?> GetCategory(int id);
        Task<IEnumerable<CategoryDTO>?> GetCategories();
        Task<IEnumerable<ProductDTO>?> GetProductsInCategory(int id);

    }
}