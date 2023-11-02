using System.ComponentModel.DataAnnotations;

namespace Zekavit_MVC.Models
{
    public class ProductMultipleImage
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "3 adet resim girmeniz gerekmektedir.")]
        public List<IFormFile> CoverPhoto { get; set; }
    }
}
