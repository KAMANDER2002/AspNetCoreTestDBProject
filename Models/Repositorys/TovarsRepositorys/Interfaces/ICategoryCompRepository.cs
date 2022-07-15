using CompMarketReal.Models.Data.Tovars;

namespace CompMarketReal.Models.Repositorys.TovarsRepositorys.Interfaces
{
    public interface ICategoryCompRepository
    {
     public IEnumerable<Category> categories { get; }
    }
}
