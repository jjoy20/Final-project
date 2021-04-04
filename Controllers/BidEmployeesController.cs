using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBDcase.Data;
using NBDcase.Models;

namespace NBDcase.Controllers
{
    public class BidEmployeesController : Controller
    {
        private readonly NBDContext _context;

        public BidEmployeesController(NBDContext context)
        {
            _context = context;
        }

        // GET: BidEmployees
        public async Task<IActionResult> Index()
        {
            var nBDContext = _context.BidEmployees
                .Include(b => b.Bid)
                .Include(b => b.Employee)
                .ThenInclude(b => b.Labor);
            return View(await nBDContext.ToListAsync());
        }

        // GET: BidEmployees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bidEmployees = await _context.BidEmployees
                .Include(b => b.Bid)
                .Include(b => b.Employee)
                 .ThenInclude(b => b.Labor)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bidEmployees == null)
            {
                return NotFound();
            }

            return View(bidEmployees);
        }

        // GET: BidEmployees/Create
        public IActionResult Create()
        {
            PopulateDropDownLists();
            ViewData["BidID"] = new SelectList(_context.Bids, "ID", "bidlist");
           // ViewData["EmployeeID"] = new SelectList(_context.Employees, "ID", "FirstName");
            return View();
        }

        // POST: BidEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,BidID,EmployeeID")] BidEmployees bidEmployees)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bidEmployees);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateDropDownLists(bidEmployees);
            ViewData["BidID"] = new SelectList(_context.Bids, "ID", "bidlist", bidEmployees.BidID);
           // ViewData["EmployeeID"] = new SelectList(_context.Employees, "ID", "FirstName", bidEmployees.EmployeeID);
            return View(bidEmployees);
        }

        // GET: BidEmployees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bidEmployees = await _context.BidEmployees.FindAsync(id);
            if (bidEmployees == null)
            {
                return NotFound();
            }
            PopulateDropDownLists(bidEmployees);
            ViewData["BidID"] = new SelectList(_context.Bids, "ID", "bidlist", bidEmployees.BidID);
            //ViewData["EmployeeID"] = new SelectList(_context.Employees, "ID", "FirstName", bidEmployees.EmployeeID);
            return View(bidEmployees);
        }

        // POST: BidEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,BidID,EmployeeID")] BidEmployees bidEmployees)
        {
            if (id != bidEmployees.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bidEmployees);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BidEmployeesExists(bidEmployees.ID))
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
            ViewData["BidID"] = new SelectList(_context.Bids, "ID", "bidlist", bidEmployees.BidID);
            PopulateDropDownLists(bidEmployees);
            // ViewData["EmployeeID"] = new SelectList(_context.Employees, "ID", "FirstName", bidEmployees.EmployeeID);
            return View(bidEmployees);
        }

        // GET: BidEmployees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bidEmployees = await _context.BidEmployees
                .Include(b => b.Bid)
                .Include(b => b.Employee)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bidEmployees == null)
            {
                return NotFound();
            }

            return View(bidEmployees);
        }

        // POST: BidEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bidEmployees = await _context.BidEmployees.FindAsync(id);
            _context.BidEmployees.Remove(bidEmployees);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BidEmployeesExists(int id)
        {
            return _context.BidEmployees.Any(e => e.ID == id);
        }
        private void PopulateDropDownLists(BidEmployees bidEmployees = null)
        {
            ViewData["EmployeeID"] = Employeelist(bidEmployees?.EmployeeID);

        }
        private object Employeelist(int? id)
        {

            var dQuery = from d in _context.Employees
                         join s in _context.Labors
                         on d.LaborID equals s.ID
                         where !s.LaborType.Contains("Designer") && !s.LaborType.Contains("Sales") && !s.LaborType.Contains("Designer Consultant")
                         orderby d.FirstName

                         select new { eid = d.ID, Ename = s.LaborType + "-" + d.FirstName };


            return new SelectList(dQuery, "eid", "Ename", id);
        }
    }
}
