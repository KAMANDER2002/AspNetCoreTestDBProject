using CompMarketReal.Models.Repositorys.TovarsRepositorys.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompMarketReal.Models.Repositorys.TovarsRepositorys.Components
{
    public class ComponetsRepository : IComponentsRepository
    {
        private readonly ILogger _logger;
        private readonly AppDbContext _appDbContext;
        public ComponetsRepository(ILogger logger, AppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }
        public IEnumerable<Data.Tovars.ComputerItems.Components> GetAllcomponents => _appDbContext.components;

        public async Task<string> AddComponent(Data.Tovars.ComputerItems.Components components)
        {
            try
            {
                var comp = await _appDbContext.components.FirstOrDefaultAsync(c => c.Name == components.Name);
                if (comp != null)
                {
                    return "такой компонент уже есть";
                }
                else
                {
                    await _appDbContext.components.AddAsync(components);
                    await _appDbContext.SaveChangesAsync();
                    return "Добавлено";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Ошибка в файле ComponentsRepository: ", ex.Message);
                return "";
            }
        }

        public async Task<string> RemoveComponent(int id)
        {
            try
            {
                var component = await _appDbContext.components.FirstOrDefaultAsync(c => c.id == id);
                if (component == null)
                {
                    return "Компонент не найден";
                }
                else
                {
                    _appDbContext.components.Remove(component);
                    await _appDbContext.SaveChangesAsync();
                    return "Удалено";
                }
            } catch (Exception ex)
            {
                _logger.LogError("Ошибка в методе RemoveComponent: ", ex.Message);
                return "";
            }
        }

        public async Task<string> UppDateComponetn(Data.Tovars.ComputerItems.Components components, int id)
        {
            try
            {
                var component = await _appDbContext.components.FirstOrDefaultAsync(c => c.id == components.id && c.id == id);
                if(component != null)
                {
                    _appDbContext.Update(components);
                    await _appDbContext.SaveChangesAsync();
                    return "Добавлено";
                } else
                {
                    return "Компонент не найден";
                }

            } catch(Exception ex)
            {
                _logger.LogError("Ошибка в методе UppDateComponent: ", ex.Message);
                return "";
            }
        }

       
    }
}
