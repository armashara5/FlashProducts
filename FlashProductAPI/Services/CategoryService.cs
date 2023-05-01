using AutoMapper;
using FlashProductAPI_7.Db;
using FlashProductAPI_7.Services.ServicesModel;
using Microsoft.EntityFrameworkCore;
namespace FlashProductAPI_7.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public CategoryService(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CategoryDTO?> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return null;
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            var mappedResult = _mapper.Map<CategoryDTO>(category);
            return mappedResult;
        }

        public async Task<IEnumerable<CategoryDTO>?> GetCategories()
        {
            if (_context.Categories == null)
            {
                return null;
            }

            var allCategories = await _context.Categories.ToListAsync();
            var mappedResult = _mapper.Map<IEnumerable<CategoryDTO>>(allCategories);
            return mappedResult;
        }

        public async Task<CategoryDTO?> GetCategory(int id)
        {
            if (_context.Categories == null)
            {
                return null;
            }
            var category = await _context.Categories.FindAsync(id);

            var mappedResult = _mapper.Map<CategoryDTO>(category);
            return mappedResult;
        }

        public async Task<IEnumerable<ProductDTO>?> GetProductsInCategory(int id)
        {
            if (_context.Categories == null)
            {
                return null;
            }
            var category = await _context.Categories.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
            {
                return null;
            }
            var mappedResult = _mapper.Map<IEnumerable<ProductDTO>?>(category.Products);
            return mappedResult;

        }
    }
}
