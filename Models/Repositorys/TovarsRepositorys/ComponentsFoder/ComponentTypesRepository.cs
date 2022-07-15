using CompMarketReal.Models.Data.Tovars.ComputerItems;
using CompMarketReal.Models.Repositorys.TovarsRepositorys.Components.Interfaces;

namespace CompMarketReal.Models.Repositorys.TovarsRepositorys.Components
{
    public class ComponentTypesRepository : IComponentTypesRepository
    {
        private readonly AppDbContext _appDbContext;
        public ComponentTypesRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<componetnType> componetnTypes => _appDbContext.componentTypes;
    }
}
