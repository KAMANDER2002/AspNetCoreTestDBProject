using System.ComponentModel.DataAnnotations;

namespace CompMarketReal.Helpers.ViewModels
{
    public class ComputersViewModel
    {
        [Required(ErrorMessage = "Укажите имя")]
        public string? ComputerName { get; set; }
        [Required(ErrorMessage = "Укажите цену")]
        public int Price { get; set; }
        public int? Discount { get; set; }
        [Required(ErrorMessage = "Укажите дату создания")]
        public DateTime? Created { get; set; }
        [Required(ErrorMessage = "Введите описание товара")]
        public string? Description { get; set; }
        public string? ImageSource { get; set; }
        public string? ErrorMessage{ get; set; }
    }
}
