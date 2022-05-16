using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WissenShop.Business.Repositories.Abstracts;
using WissenShop.Core.Entities;
using WissenShop.Web.Core.ViewModels.Dashboard;

namespace WissenShop.Web.Core.Components
{
    public class CategoryReportViewComponent : ViewComponent
    {
        private readonly IRepository<Category, int> _categoryRepo;

        public CategoryReportViewComponent(IRepository<Category, int> categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public IViewComponentResult Invoke()
        {
            var data = _categoryRepo.Get()
                .Include(x => x.Products)
                .Select(x => new CategoryReportViewModel()
                {
                    Name = x.Name,
                    ProductCount = x.Products.Count
                }).ToList();

            return View(data);
        }
    }
}