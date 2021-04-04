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
    [Authorize(Roles = "Admin")]
    public class EmployeeAccsController : Controller
    {
        private readonly NBDContext _context;
        private readonly ApplicationDbContext _identityContext;

        public EmployeeAccsController(NBDContext context, ApplicationDbContext identityContext)
        {
            _context = context;
            _identityContext = identityContext;
        }

        // GET: EmployeeAccs
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmployeeAccs.ToListAsync());
        }

        //// GET: EmployeeAccs/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var employeeAcc = await _context.EmployeeAcc
        //        .FirstOrDefaultAsync(m => m.ID == id);
        //    if (employeeAcc == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(employeeAcc);
        //}


        // GET: EmployeeAccs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeAcc = await _context.EmployeeAccs.FindAsync(id);
            if (employeeAcc == null)
            {
                return NotFound();
            }
            return View(employeeAcc);
        }

        // POST: EmployeeAccs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, bool Active)
        {
            var employeeToUpdate = await _context.EmployeeAccs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (employeeToUpdate == null)
            {
                return NotFound();
            }

            //Check to see if you are making them inactive
            if (employeeToUpdate.Active == true && Active == false)
            {
                //This deletes the user's login from the security system
                await DeleteIdentityUser(employeeToUpdate.Email);

            }

            if (await TryUpdateModelAsync<EmployeeAcc>(employeeToUpdate, "",
                e => e.FirstName, e => e.LastName, e => e.Phone, e => e.FavouriteIceCream, e => e.Active))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeAccExists(employeeToUpdate.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(employeeToUpdate);
        }

        private async Task DeleteIdentityUser(string Email)
        {
            var userToDelete = await _identityContext.Users.Where(u => u.Email == Email).FirstOrDefaultAsync();
            if (userToDelete != null)
            {
                _identityContext.Users.Remove(userToDelete);
                await _identityContext.SaveChangesAsync();
            }
        }

        private bool EmployeeAccExists(int id)
        {
            return _context.EmployeeAccs.Any(e => e.ID == id);
        }
    }
}
