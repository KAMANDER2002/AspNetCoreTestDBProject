using CompMarketReal.Helpers.ViewModels;
using CompMarketReal.Models;
using CompMarketReal.Models.Data.Tovars;
using CompMarketReal.Models.Repositorys.TovarsRepositorys.Computers;
using CompMarketReal.Models.Repositorys.TovarsRepositorys.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace CompMarketReal.Controllers.TovarsControllers
{
    public class ComputersController:Controller
    {
        private readonly AppDbContext _appDbContex;
        private IComputersRepository computersRepository;
        public ComputersController(IComputersRepository computersRepository, AppDbContext appDbContext)
        {
            this.computersRepository = computersRepository;
            _appDbContex = appDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var computers = await computersRepository.GetAllcomputers();
            return computers != null ? View(computers) : Problem("Товары не найдены");
        }
        
        public IActionResult AddTovar()
        {
          var CVM = new ComputersViewModel();
          return View(CVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTovar(ComputersViewModel model)
        {
            if (string.IsNullOrEmpty(model.ErrorMessage))
            {
                model.ErrorMessage = " ";
            }
            if(model.Discount == null)
            {
                model.Discount = 0;
            }
            if (string.IsNullOrEmpty(model.ImageSource))
            {
                model.ImageSource = "/images/test-image";
            }
            if (ModelState.IsValid)
            {
                if (await computersRepository.AddComputer(model) == "Добавлено")
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    model.ErrorMessage = await computersRepository.AddComputer(model);
                    return View(model);
                }
            }
            else return View(model); 

        }
        [HttpGet]
        public async Task<IActionResult> DeleteTovar(int? id)
        {
            try {
                if (id == null || _appDbContex.computers == null)
                {
                    return NotFound();
                }

                var users = await _appDbContex.computers.FirstOrDefaultAsync(c => c.id == id);
                if (users == null)
                {
                    return NotFound();
                }
                return View(users);
            } catch (Exception ex)
            {
                return View(ex);
             }
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_appDbContex.computers == null)
            {
                return Problem("Entity set 'AppDBContext.Users'  is null.");
            }
            var users = await _appDbContex.computers.FindAsync(id);
            if (users != null)
            {
                _appDbContex.computers.Remove(users);
            }

            await _appDbContex.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> UppdateComputer(int? id)
        {
            if (id == null || _appDbContex.computers == null)
            {
                return NotFound();
            }
            var comp = await _appDbContex.computers.FindAsync(id);
            if (comp != null)
            {
                return View(comp);
            }
            else return NotFound();

        }
        [HttpPost]
        public async Task<IActionResult> UppdateComputer(int id, Computer computer)
        {
            if(computer.Category == null)
            {
                computer.Category = _appDbContex.categories.FirstOrDefault(k => k.Id == 1);
            }
            if(id!= computer.id)
            {
                return NotFound();
            }
           
            if (string.IsNullOrEmpty(computer.imageSource))
            {
                computer.imageSource = "/images/test-image";
            }
            if (ModelState.IsValid)
            {
              try
              {
                    if (await computersRepository.UppDateComputer(computer) == "Обновлено")
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else return Problem( await computersRepository.UppDateComputer(computer));
              }
              catch
              {
               if (!ComputerExists(id))
               {
                        return NotFound();
               } else 
               {
                        throw;
               }
              }
            } else 
            return View();
        }
        private bool ComputerExists(int id)
        {
            return (_appDbContex.computers?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
