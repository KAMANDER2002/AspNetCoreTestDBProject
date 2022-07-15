using CompMarketReal.Helpers.ViewModels;
using CompMarketReal.Models.Data.Tovars;

namespace CompMarketReal.Models.Repositorys.TovarsRepositorys.Interfaces
{
    public interface IComputersRepository
    {
        public Task<IEnumerable<Computer>> GetAllcomputers();
        public Task<string> AddComputer(ComputersViewModel model);
        public Task<string> UppDateComputer(Computer components);
        public Task<string> RemoveComputer(int id);
    }
}
