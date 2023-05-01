using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FlashProductAPI_7.Db;
using FlashProductAPI_7.Db.DbModels;
using FlashProductAPI_7.Services;
using FlashProductAPI_7.Services.ServicesModel;

namespace FlashProductAPI_7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductService? _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
        {
            if (_productService == null)
            {
                return NotFound();
            }
            IEnumerable<ProductDTO>? products = await _productService.GetProducts();
            if (products == null)
            {
                return NotFound();
            }
            return new ActionResult<IEnumerable<ProductDTO>>(products);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO?>> GetProduct(int id)
        {
            if (_productService == null)
            {
                return NotFound();
            }
            ProductDTO? product = await _productService.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, ProductDTO product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            if (_productService == null)
            {
                return NotFound();
            }
            try
            {

                await _productService.PutProduct(id, product);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_productService.ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw new Exception("ConcurrencyException occured");
                }
            }

            return NoContent();
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<ProductDTO>> PostProduct(ProductDTO product)
        {
            if (_productService == null || product == null)
            {
                return NotFound();
            }
            try
            {
                var result = await _productService.PostProduct(product);
                if (result == null)
                {
                    return NotFound();
                }
                //return CreatedAtAction("PostProduct", new { id = result.Id }, result);
                return CreatedAtAction("PostProduct", new { id = result.Id }, result);
            }
            catch (Exception)
            {
                throw;
            }

        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (_productService == null)
            {
                return NotFound();
            }
            try
            {
                var product = await _productService.DeleteProduct(id);
                if (product == null)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
