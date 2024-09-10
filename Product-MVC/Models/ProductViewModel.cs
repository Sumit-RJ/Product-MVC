using System.ComponentModel.DataAnnotations;

namespace Product_MVC.Models
{
	public class ProductViewModel
	{

		public int Id { get; set; }

		[Required(ErrorMessage = "The Name field is required.")]
		public string Name { get; set; }
		[Required(ErrorMessage = "The Price field is required.")]
		public decimal? Price { get; set; }
		[Required(ErrorMessage = "The Category field is required.")]
		public string Category { get; set; }
	}
}
