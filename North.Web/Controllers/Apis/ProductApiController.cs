using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using North.Businesss.Repositories.Abstracts;
using North.Core.Entities;

namespace North.Web.Controllers.Apis
{
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly IRepository<Product, int> _productRepo;

        public ProductApiController(IRepository<Product, int> productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var data = _productRepo.GetById(id);
            if (data == null)
                return NotFound("Ürün bulunamadı");
            return Ok(data);
        }
    }
}
