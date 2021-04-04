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

namespace NBDcase.Controllers
{
    [Authorize]
    public class EmployeeAccountController : Controller
    {
        //Specialized controller just used to allow an 
        //Authenticated user to maintain their own  account details.

        private readonly NBDContext _context;

        public EmployeeAccountController(NBDContext context)
        {
            _context = context;
        }

        // GET: EmployeeAccount
        public IActionResult Index()
        {
            return RedirectToAction(nameof(Details));
        }

        // GET: EmployeeAccount/Details/5
        public async Task<IActionResult> Details()
        {

            var employee = await _context.EmployeeAccs
               .Where(c => c.Email == User.Identity.Name)
               .FirstOrDefaultAsync();
            if (employee == null)
            {
                return RedirectToAction(nameof(Create));
            }

            return View(employee);
        }

        // GET: EmployeeAccount/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeAccount/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(",FirstName,LastName,Phone,FavouriteIceCream,Email")] EmployeeAcc employeeAcc)
        {
            employeeAcc.Email = User.Identity.Name;
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(employeeAcc);
                    await _context.SaveChangesAsync();
                    UpdateUserNameCookie(employeeAcc.FullName);
                    return RedirectToAction(nameof(Details));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(employeeAcc);
        }

        // GET: EmployeeAccount/Edit/5
        public async Task<IActionResult> Edit()
        {
            var employee = await _context.EmployeeAccs
                .Where(c => c.Email == User.Identity.Name)
                .FirstOrDefaultAsync();
            if (employee == null)
            {
                return RedirectToAction(nameof(Create));
            }
            return View(employee);
        }

        // POST: EmployeeAccount/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id)
        {

            var employeeToUpdate = await _context.EmployeeAccs
                .FirstOrDefaultAsync(m => m.ID == id);

            if (await TryUpdateModelAsync<EmployeeAcc>(employeeToUpdate, "",
                c => c.FirstName, c => c.LastName, c => c.Phone, c => c.FavouriteIceCream))
            {
                try
                {
                    _context.Update(employeeToUpdate);
                    await _context.SaveChangesAsync();
                    UpdateUserNameCookie(employeeToUpdate.FullName);
                    return RedirectToAction(nameof(Details));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeAccExists(employeeToUpdate.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Unable to save changes. The record you attempted to edit "
                                + "was modified by another user after you received your values.  You need to go back and try your edit again.");
                    }
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Something went wrong in the database.");
                }
            }
            return View(employeeToUpdate);
        }

        private void UpdateUserNameCookie(string userName)
        {
            CookieHelper.CookieSet(HttpContext, "userName", userName, 960);
        }

        private bool EmployeeAccExists(int id)
        {
            return _context.EmployeeAccs.Any(e => e.ID == id);
        }
    }
}
