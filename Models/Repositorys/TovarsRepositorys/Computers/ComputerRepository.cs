using CompMarketReal.Helpers.ViewModels;
using CompMarketReal.Models.Data.Tovars;
using CompMarketReal.Models.Repositorys.TovarsRepositorys.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CompMarketReal.Models.Repositorys.TovarsRepositorys.Computers
{
    public class ComputerRepository : IComputersRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ICategoryCompRepository _categoryRepository;
        public ComputerRepository(AppDbContext appDbContext, ICategoryCompRepository categoryRepository)
        {
           
            _appDbContext = appDbContext;
            _categoryRepository = categoryRepository;
        }
        public async Task<IEnumerable<Computer>> GetAllcomputers() => await _appDbContext.computers.ToListAsync();


        public async Task<string> AddComputer(ComputersViewModel model)
        {
            try
            {
                
                var comp = await _appDbContext.computers.FirstOrDefaultAsync(c => c.ComputerName == model.ComputerName);
                if (comp != null)
                {
                    return "такой компьютер уже есть";
                }
                else
                {
                    Computer computers = new Computer() { ComputerName = model.ComputerName,imageSource = model.ImageSource, Price = model.Price, Discount = model.Discount, Description = model.Description, Created = model.Created, Category = _categoryRepository.categories.FirstOrDefault(k => k.Id == 1)};
                    await _appDbContext.computers.AddAsync(computers);
                    await _appDbContext.SaveChangesAsync();
                    return "Добавлено";
                }
            }
            catch (Exception ex)
            {
                
                return ex.Message;
            }
        }

        public async Task<string> RemoveComputer(int id)
        {
            try
            {
                var computer = await _appDbContext.computers.FirstOrDefaultAsync(c => c.id == id);
                if (computer == null)
                {
                    return "Компонент не найден";
                }
                else
                {
                    _appDbContext.computers.Remove(computer);
                    await _appDbContext.SaveChangesAsync();
                    return "Удалено";
                }
            }
            catch (Exception ex)
            {
                
                return "";
            }
        }

        public async Task<string> UppDateComputer(Computer computer)
        {
            try
            {
                
                    _appDbContext.Update(computer);
                    await _appDbContext.SaveChangesAsync();
                    return "Обновлено";
               

            }
            catch (Exception ex)
            {
                
                return "";
            }
        }

        
    }
}
