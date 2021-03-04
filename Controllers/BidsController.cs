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
    public class BidsController : Controller
    {
        private readonly NBDContext _context;

        public BidsController(NBDContext context)
        {
            _context = context;
        }

        // GET: Bids
        public async Task<IActionResult> Index()
        {
            var nBDContext = _context.Bids.Include(b => b.Designer).Include(b => b.Project).Include(b => b.Sales);
            return View(await nBDContext.ToListAsync());
        }

        // GET: Bids/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bid = await _context.Bids
                .Include(b => b.Designer)
                .Include(b => b.Project)
                .Include(b => b.Sales)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bid == null)
            {
                return NotFound();
            }

            return View(bid);
        }

        // GET: Bids/Create
        public IActionResult Create()
        {
            ViewData["DesignerID"] = new SelectList(_context.Designers, "ID", "FirstName");
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "ProjectName");
            ViewData["SalesID"] = new SelectList(_context.Sales, "ID", "FirstName");
            return View();
        }

        // POST: Bids/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,BidDate,EstBeginDate,EstComplDate,BidAmount,BidHours,ApprovalbyNBD,ApprovalbyClient,ProjectID,DesignerID,SalesID")] Bid bid)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bid);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DesignerID"] = new SelectList(_context.Designers, "ID", "FirstName", bid.DesignerID);
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "ProjectName", bid.ProjectID);
            ViewData["SalesID"] = new SelectList(_context.Sales, "ID", "FirstName", bid.SalesID);
            return View(bid);
        }

        // GET: Bids/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bid = await _context.Bids.FindAsync(id);
            if (bid == null)
            {
                return NotFound();
            }
            ViewData["DesignerID"] = new SelectList(_context.Designers, "ID", "FirstName", bid.DesignerID);
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "ProjectName", bid.ProjectID);
            ViewData["SalesID"] = new SelectList(_context.Sales, "ID", "FirstName", bid.SalesID);
            return View(bid);
        }

        // POST: Bids/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,BidDate,EstBeginDate,EstComplDate,BidAmount,BidHours,ApprovalbyNBD,ApprovalbyClient,ProjectID,DesignerID,SalesID")] Bid bid)
        {
            if (id != bid.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bid);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BidExists(bid.ID))
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
            ViewData["DesignerID"] = new SelectList(_context.Designers, "ID", "FirstName", bid.DesignerID);
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "ProjectName", bid.ProjectID);
            ViewData["SalesID"] = new SelectList(_context.Sales, "ID", "FirstName", bid.SalesID);
            return View(bid);
        }

        // GET: Bids/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bid = await _context.Bids
                .Include(b => b.Designer)
                .Include(b => b.Project)
                .Include(b => b.Sales)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bid == null)
            {
                return NotFound();
            }

            return View(bid);
        }

        // POST: Bids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bid = await _context.Bids.FindAsync(id);
            _context.Bids.Remove(bid);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BidExists(int id)
        {
            return _context.Bids.Any(e => e.ID == id);
        }
    }
}
