﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hero.Models;

namespace Hero.Controllers
{
    public class HeroesController : Controller
    {
        private readonly HeroContext _context;

        public HeroesController(HeroContext context)
        {
            _context = context;
        }

        // GET: Heroes
        public async Task<IActionResult> Index()
        {
              return _context.Heroes != null ? 
                          View(await _context.Heroes.ToListAsync()) :
                          Problem("Entity set 'HeroContext.Heroes'  is null.");
        }

        // GET: Heroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Heroes == null)
            {
                return NotFound();
            }

            var hero = await _context.Heroes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hero == null)
            {
                return NotFound();
            }

            return View(hero);
        }

        // GET: Heroes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Heroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom")] Hero hero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hero);
        }

        // GET: Heroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Heroes == null)
            {
                return NotFound();
            }

            var hero = await _context.Heroes.FindAsync(id);
            if (hero == null)
            {
                return NotFound();
            }
            return View(hero);
        }

        // POST: Heroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom")] Hero hero)
        {
            if (id != hero.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HeroExists(hero.Id))
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
            return View(hero);
        }

        // GET: Heroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Heroes == null)
            {
                return NotFound();
            }

            var hero = await _context.Heroes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hero == null)
            {
                return NotFound();
            }

            return View(hero);
        }

        // POST: Heroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Heroes == null)
            {
                return Problem("Entity set 'HeroContext.Heroes'  is null.");
            }
            var hero = await _context.Heroes.FindAsync(id);
            if (hero != null)
            {
                _context.Heroes.Remove(hero);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HeroExists(int id)
        {
          return (_context.Heroes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
