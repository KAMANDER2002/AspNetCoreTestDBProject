namespace CompMarketReal.Models.Data.Tovars
{
    public class Computer
    {
         public int id { get; set; }
         public string? imageSource { get; set; }
         public string? ComputerName { get; set; }
         public int Price { get; set; }
         public int? Discount { get; set; }
         public DateTime? Created { get; set; }
         public string? Description { get; set; }
         public virtual Category? Category { get; set; }
    }
}
