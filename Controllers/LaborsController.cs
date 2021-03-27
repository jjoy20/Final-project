using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBDcase.Data;
using NBDcase.Models;

namespace NBDcase.Controllers
{
    [Authorize]
    public class LaborsController : Controller
    {
        private readonly NBDContext _context;

        public LaborsController(NBDContext context)
        {
            _context = context;
        }

        // GET: Labors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Labors.ToListAsync());
        }

        // GET: Labors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labor = await _context.Labors
                .FirstOrDefaultAsync(m => m.ID == id);
            if (labor == null)
            {
                return NotFound();
            }

            return View(labor);
        }

        // GET: Labors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Labors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,LaborType,LaborPrice,LaborCost")] Labor labor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(labor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(labor);
        }

        // GET: Labors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labor = await _context.Labors.FindAsync(id);
            if (labor == null)
            {
                return NotFound();
            }
            return View(labor);
        }

        // POST: Labors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,LaborType,LaborPrice,LaborCost")] Labor labor)
        {
            if (id != labor.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(labor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LaborExists(labor.ID))
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
            return View(labor);
        }

        // GET: Labors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labor = await _context.Labors
                .FirstOrDefaultAsync(m => m.ID == id);
            if (labor == null)
            {
                return NotFound();
            }

            return View(labor);
        }

        // POST: Labors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var labor = await _context.Labors.FindAsync(id);
            _context.Labors.Remove(labor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LaborExists(int id)
        {
            return _context.Labors.Any(e => e.ID == id);
        }
    }
}
