using CougModels;
using CougNet.Data;
using CougNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CougNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var progList = new List<CougProgram>();

            if (!string.IsNullOrEmpty(User.Identity.Name))
            {
                //check if user is a coug
                var coug = _context.Coug.FirstOrDefault(x => x.AppId == User.Identity.Name);
                if (coug == null)
                {
                    //create dummy coug
                    coug = new Coug
                    {
                        AppId = User.Identity.Name
                    };
                    _context.Coug.Add(coug);
                    _context.SaveChangesAsync();

                }
                progList = _context.CougProgram.Where(x => x.IsActive && x.IsPublic).ToList();

                foreach (var prog in progList)
                {
                    //check if registered
                    prog.IsRegistered = IsRegistered(coug, prog);
                    prog.IsOwner = (prog.CreatedBy == User.Identity.Name);
                }

                //ViewBag.Progams = progList;
            }
      
            return View(progList);
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

        private bool IsRegistered(Coug coug, CougProgram prog)
        {
            return (_context.CougProgramRegistrations.FirstOrDefault(x => x.Coug.Id == coug.Id && x.CougProgram.Id == prog.Id) != null);
        }
    }
}
