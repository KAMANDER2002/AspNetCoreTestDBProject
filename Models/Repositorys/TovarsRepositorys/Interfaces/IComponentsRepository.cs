
namespace CompMarketReal.Models.Repositorys.TovarsRepositorys.Interfaces
{
    public interface IComponentsRepository
    {
        public IEnumerable<CompMarketReal.Models.Data.Tovars.ComputerItems.Components> GetAllcomponents { get; }
        public Task<string> AddComponent(CompMarketReal.Models.Data.Tovars.ComputerItems.Components components);
        public Task<string> UppDateComponetn(CompMarketReal.Models.Data.Tovars.ComputerItems.Components components, int id);
        public Task<string> RemoveComponent(int id);
    }
}
