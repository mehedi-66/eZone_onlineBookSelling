using eZone.DataAccess.Repository.IRepository;
using eZone.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace eZone.Areas.Customer.Controllers
{
    [Area("Customer")]  
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> product = _unitOfWork.Product.GetAll(includeProperties: "Category");
            return View(product);
        }


        public IActionResult Details(int id)
        {
            ShopingCart cartObj = new()
            {
                Count = 1,
                Product = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id, includeProperties: "Category")
             }; 
            return View(cartObj);
        } 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}