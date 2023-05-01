using AutoMapper;
using FlashProductAPI_7.Db;
using FlashProductAPI_7.Db.DbModels;
using FlashProductAPI_7.Services.ServicesModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace FlashProductAPI_7.Services
{
    public class ProductService : IProductService
    {
        private readonly MyDbContext _context;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IMapper _mapper;

        public ProductService(MyDbContext context, IDateTimeProvider dateTimeProvider, IMapper mapper)
        {
            _context = context;
            _dateTimeProvider = dateTimeProvider;
            _mapper = mapper;
        }

        public async Task<ProductDTO?> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return null;
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            var mappedResult = _mapper.Map<ProductDTO>(product);
            return mappedResult;
        }

        public async Task<ProductDTO?> GetProduct(int id)
        {
            if (_context.Products == null)
            {
                return null;
            }
            var product = await _context.Products.FindAsync(id);

            var mappedResult = _mapper.Map<ProductDTO>(product);
            return mappedResult;
        }

        public async Task<IEnumerable<ProductDTO>?> GetProducts()
        {
            if (_context.Products == null)
            {
                return null;
            }

            var allProducts = await _context.Products.ToListAsync();
            var products = allProducts.
                  Where(x => x.StartDate <= _dateTimeProvider.Now && x.StartDate.Add(x.Duration) >= _dateTimeProvider.Now)
                  .ToList();

            ////Another way to get the products is using raw sql query
            //string q = "SELECT * FROM products  WHERE startdate <= {0}  AND DATEADD(millisecond, DATEDIFF(millisecond, 0, startdate),  CAST(duration AS datetime)) >= {0} ";
            //var products = _context.Products
            //    .FromSqlRaw<Product>(q,_dateTimeProvider.Now)
            //    .ToListAsync();

            var mappedResult = _mapper.Map<IEnumerable<ProductDTO>?>(products);
            return mappedResult;
        }

        public async Task<ProductDTO?> PostProduct(ProductDTO product)
        {
            if (product.Price < 0)
            {
                throw new Exception("Price must have a positive value");
            }
            if (_context.Products == null)
            {
                return null;
            }
            var mappedProduct = _mapper.Map<Product>(product);
            _context.Products.Add(mappedProduct);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<ProductDTO>(mappedProduct);
            return result;
        }

        public async Task PutProduct(int id, ProductDTO product)
        {
            var mappedProduct = _mapper.Map<Product>(product);
            _context.Entry(mappedProduct).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public bool ProductExists(int id)
        {
            return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
