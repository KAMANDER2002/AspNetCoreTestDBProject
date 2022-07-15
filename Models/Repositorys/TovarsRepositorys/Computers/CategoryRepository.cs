using CompMarketReal.Models.Data.Tovars;
using CompMarketReal.Models.Repositorys.TovarsRepositorys.Interfaces;

namespace CompMarketReal.Models.Repositorys.TovarsRepositorys.Computers
{
    public class CategoryRepository : ICategoryCompRepository
    {
         private readonly AppDbContext _appDbContext;
         public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Category> categories => _appDbContext.categories.ToList();
    }
}
