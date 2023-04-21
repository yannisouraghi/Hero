using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hero.Models;
using Hero.Services;

namespace Hero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PowersController : Controller
    {
        private readonly IPowerService _powerService;

        public PowersController(Power powerService)
        {
            _powerService = (IPowerService?)powerService;
        }

        // GET: Powers
        [HttpGet]
        public async Task<ActionResult<List<Power>>> getAllPowers()
        {
            return await _powerService.getAllPowers();
        }

        // GET: Powers/Details/5
        [HttpGet("(id)")]
        public async Task<List<Power>> GetPowers(int id)
        {
            var powers = await _powerService.getPowers(id);
            if (powers == null)
            {
                return null;
            }
            return Ok(powers);
        }

        // GET: Powers/Create

        public IActionResult Create()
        {
            return View();
        }

        // POST: Powers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PowerName")] Power power)
        {
            if (ModelState.IsValid)
            {
                _context.Add(power);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(power);
        }

        // GET: Powers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Powers == null)
            {
                return NotFound();
            }

            var power = await _context.Powers.FindAsync(id);
            if (power == null)
            {
                return NotFound();
            }
            return View(power);
        }

        // POST: Powers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PowerName")] Power power)
        {
            if (id != power.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(power);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PowerExists(power.Id))
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
            return View(power);
        }

        // GET: Powers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Powers == null)
            {
                return NotFound();
            }

            var power = await _context.Powers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (power == null)
            {
                return NotFound();
            }

            return View(power);
        }

        // POST: Powers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Powers == null)
            {
                return Problem("Entity set 'HeroContext.Powers'  is null.");
            }
            var power = await _context.Powers.FindAsync(id);
            if (power != null)
            {
                _context.Powers.Remove(power);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PowerExists(int id)
        {
          return (_context.Powers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
