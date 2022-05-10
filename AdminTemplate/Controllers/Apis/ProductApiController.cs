using AdminTemplate.Data;
using AdminTemplate.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdminTemplate.Controllers.Apis
{
    [ApiController]
    public class ProductApiController : BaseApiController
    {
        private readonly MyContext _context;

        public ProductApiController(MyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var product = _context.Products.Find(id);
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Add(Product model)
        {
            try
            {
                _context.Products.Add(model);
                _context.SaveChanges();
                return Ok(new
                {
                    Success = true,
                    Message = $"{model.Name} isimli ürün kaydedildi"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, Product model)
        {
            try
            {
                var product = _context.Products.Find(id);
                if (product == null)
                {
                    return NotFound(new { Success = false, Message = "Ürün bulunamadı" });
                }

                product.Name = model.Name;
                product.UnitPrice = model.UnitPrice;
                product.CategoryId = model.CategoryId;
                _context.SaveChanges();
                return Ok(new
                {
                    Success = true,
                    Message = $"{model.Name} isimli ürün güncellendi"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var product = _context.Products.Find(id);
                if (product == null)
                {
                    return NotFound(new { Success = false, Message = "Ürün bulunamadı" });
                }

                _context.Products.Remove(product);
                _context.SaveChanges();
                return Ok(new
                {
                    Success = true,
                    Message = $"{product.Name} isimli ürün silindi"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }
    }
}