using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NBDcase.Data;
using NBDcase.Models;
using NBDcase.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NBDcase.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly NBDContext _context;

        public HomeController(ILogger<HomeController> logger, NBDContext context)
        {
            _context = context;

            _logger = logger;
        }

        public IActionResult Index()
        {
            var vm = new HomeVM();

            var bids = _context.Bids
                .Include(b => b.Project)
                .Where(b => b.ID >= (_context.Bids.FirstOrDefault().ID + 5))
                .ToList();

            var clients = _context.Clients
                .Where(b => b.ID >= (_context.Clients.FirstOrDefault().ID + 5))
                .ToList();

            var projects = _context.Projects
                .Include(p => p.Client)
                .Where(b => b.ID >= (_context.Projects.FirstOrDefault().ID + 5))
                .ToList();

            vm.Bids = bids;
            vm.Clients = clients;
            vm.Projects = projects;

            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
