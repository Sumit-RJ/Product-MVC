using Microsoft.AspNetCore.Mvc;
using Product_MVC.Models;
using Product_MVC.Repositories;
using System.Reflection;

namespace Product_MVC.Controllers
{
	public class ProductsController : Controller
	{
		private readonly IProductRepository _productRepository;
		public ProductsController(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}
		public IActionResult Index()
		{
			List<ProductViewModel> products = _productRepository.GetAllProducts().Result;
			return View(products);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(ProductViewModel product)
		{
			if (ModelState.IsValid)
			{
				_productRepository.CreateProduct(product);
				ModelState.Clear();
				return View();
			}
			return View(product);

		}
	}
}
