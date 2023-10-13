using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography.X509Certificates;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> Products;
        private readonly IProductServices _services;
        public IndexModel(IProductServices services)
        {
            _services = services;
                
        }
        public void OnGet()
        {
         
            Products = _services.GetProduct();

        }
    }
}