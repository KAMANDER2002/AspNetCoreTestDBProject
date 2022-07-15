using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CompMarketReal.Models;
using CompMarketReal.Models.Data.Tovars.ComputerItems;
using CompMarketReal.Helpers.ViewModels;

namespace CompMarketReal.Controllers.TovarsControllers
{
    public class ComponentsController : Controller
    {
        private readonly AppDbContext _context;

        public ComponentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Components
        public async Task<IActionResult> Index()
        {

            var model = new ComponentViewModel() { components = await _context.components.ToListAsync(), componetnTypes = await _context.componentTypes.ToListAsync() };
              return model != null ? 
                          View(model) :
                          Problem("Entity set 'AppDbContext.components'  is null.");
        }

        // GET: Components/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.components == null)
            {
                return NotFound();
            }

            var components = await _context.components
                .FirstOrDefaultAsync(m => m.id == id);
            if (components == null)
            {
                return NotFound();
            }

            return View(components);
        }

        // GET: Components/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Components/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Name,EnergoPotrebl,Seria,DateCreate,Type,SpeedChtenia,SpeedWrite,Socket,Slots,TypeCollers,DDRType,Volts,Description")] Components components)
        {
            if (ModelState.IsValid)
            {
                _context.Add(components);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(components);
        }

        // GET: Components/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.components == null)
            {
                return NotFound();
            }

            var components = await _context.components.FindAsync(id);
            if (components == null)
            {
                return NotFound();
            }
            return View(components);
        }

        // POST: Components/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Name,EnergoPotrebl,Seria,DateCreate,Type,SpeedChtenia,SpeedWrite,Socket,Slots,TypeCollers,DDRType,Volts,Description")] Components components)
        {
            if (id != components.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(components);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComponentsExists(components.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(components);
        }

        // GET: Components/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.components == null)
            {
                return NotFound();
            }

            var components = await _context.components
                .FirstOrDefaultAsync(m => m.id == id);
            if (components == null)
            {
                return NotFound();
            }

            return View(components);
        }

        // POST: Components/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.components == null)
            {
                return Problem("Entity set 'AppDbContext.components'  is null.");
            }
            var components = await _context.components.FindAsync(id);
            if (components != null)
            {
                _context.components.Remove(components);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComponentsExists(int id)
        {
          return (_context.components?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
