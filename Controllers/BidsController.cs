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
using NBDcase.Utilities;
using sol_Job_Bank.Utilities;

namespace NBDcase.Controllers
{
    [Authorize]
    public class BidsController : Controller
    {
        private readonly NBDContext _context;

        public BidsController(NBDContext context)
        {
            _context = context;
        }

        // GET: Bids
        public async Task<IActionResult> Index(int? page, int? pageSizeID, string SearchBudget, string Searchenddate, string actionButton, string sortDirection = "desc", string sortField = "ID")
        {
            var bids = from b  in _context.Bids
                       .Include(b => b.Designer)
                       .Include(b => b.Project)
                       .ThenInclude(b => b.Client)
                       .Include(b => b.Sales)
                       .Include(b => b.Inventories)
                       .ThenInclude(b => b.Material)
                       select b;


            int pageSize;//This is the value we will pass to PaginatedList
            if (pageSizeID.HasValue)
            {
                //Value selected from DDL so use and save it to Cookie
                pageSize = pageSizeID.GetValueOrDefault();
                CookieHelper.CookieSet(HttpContext, "pageSizeValue", pageSize.ToString(), 30);
            }
            else
            {
                //Not selected so see if it is in Cookie
                pageSize = Convert.ToInt32(HttpContext.Request.Cookies["pageSizeValue"]);
            }
            pageSize = (pageSize == 0) ? 3 : pageSize;//Neither Selected or in Cookie so go with default
            ViewData["pageSizeID"] =
                new SelectList(new[] { "3", "5", "10", "20", "30", "40", "50", "100", "500" }, pageSize.ToString());
            ViewData["Filtering"] = "";

            if (!String.IsNullOrEmpty(SearchBudget))
            {
                bids=bids.Where(p => p.BidAmount.Equals(SearchBudget));
                ViewData["Filtering"] = " show";
            }
            if (!String.IsNullOrEmpty(Searchenddate))
            {
                bids = bids.Where(p => p.EstComplDate.ToString("d").Equals(Searchenddate));
                ViewData["Filtering"] = " show";
            }
            if (!String.IsNullOrEmpty(actionButton)) //Form Submitted so lets sort!
            {
                page = 1;//Reset page to start

                if (actionButton != "Filter")//Change of sort is requested
                {
                    if (actionButton == sortField) //Reverse order on same field
                    {
                        sortDirection = sortDirection == "asc" ? "desc" : "asc";
                    }
                    sortField = actionButton;//Sort by the button clicked
                }
            }
            //Now we know which field and direction to sort by
            if (sortField == "ID")
            {
                if (sortDirection == "desc")
                {
                   bids = bids
                        .OrderByDescending(p => p.ID);
                }
                else
                {
                    bids = bids
                        .OrderBy(p => p.ID);
                }
            }
            else if (sortField == "EstBeginDate")
            {
                if (sortDirection == "desc")
                {
                    bids = bids
                        .OrderByDescending(p => p.EstBeginDate);
                }
                else
                {
                    bids = bids
                        .OrderBy(p => p.EstBeginDate);
                }
            }
            
            //Set sort for next time
            ViewData["sortField"] = sortField;
            ViewData["sortDirection"] = sortDirection;
            var PageData = await PaginatedList<Bid>.CreateAsync(bids.AsNoTracking(), page ?? 1, pageSize);
         
            return View(PageData);
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
                .ThenInclude(b=>b.Client)
                .Include(b => b.Sales)
                .Include(b => b.Inventories)
                .ThenInclude(b => b.Material)
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
            
            ViewData["DesignerID"] = new SelectList(_context.Employees, "ID", "FirstName");
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Projectlist");
            ViewData["SalesID"] = new SelectList(_context.Employees, "ID", "FirstName");
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
            ViewData["DesignerID"] = new SelectList(_context.Employees, "ID", "FirstName", bid.DesignerID);
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Projectlist", bid.ProjectID);
            ViewData["SalesID"] = new SelectList(_context.Employees, "ID", "FirstName", bid.SalesID);
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
            ViewData["DesignerID"] = new SelectList(_context.Employees, "ID", "FirstName", bid.DesignerID);
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "ProjectName", bid.ProjectID);
            ViewData["SalesID"] = new SelectList(_context.Employees, "ID", "FirstName", bid.SalesID);
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
            ViewData["DesignerID"] = new SelectList(_context.Employees, "ID", "FirstName", bid.DesignerID);
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Projectlist", bid.ProjectID);
            ViewData["SalesID"] = new SelectList(_context.Employees, "ID", "FirstName", bid.SalesID);
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
