using System.ComponentModel.DataAnnotations;

namespace WissenShop.Web.Core.ViewModels.Dashboard
{
    public class ProductReportViewModel
    {
        [Display(Name ="Adet")]
        public int Count { get; set; }
        [Display(Name = "Toplam")]
        public decimal Total { get; set; }
    }
}