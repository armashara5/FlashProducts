using FlashProductAPI_7.Db.DbModels;
using FlashProductAPI_7.Services.ServicesModel;
using Microsoft.AspNetCore.Mvc;

namespace FlashProductAPI_7.Services
{
    public interface IProductService
    {
        Task<ProductDTO?> DeleteProduct(int id);
        Task<ProductDTO?> GetProduct(int id);
        Task<IEnumerable<ProductDTO>?> GetProducts();
        Task<ProductDTO?> PostProduct(ProductDTO product);
        bool ProductExists(int id);
        Task PutProduct(int id, ProductDTO product);

    }
}