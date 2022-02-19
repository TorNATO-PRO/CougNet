using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CougModels;
using CougNet.Data;

namespace CougNet
{
    public class CougYearController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CougYearController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CougYear
        public async Task<IActionResult> Index()
        {
            return View(await _context.CougYear.ToListAsync());
        }

        // GET: CougYear/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cougYear = await _context.CougYear
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cougYear == null)
            {
                return NotFound();
            }

            return View(cougYear);
        }

        // GET: CougYear/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CougYear/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Year")] CougYear cougYear)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cougYear);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cougYear);
        }

        // GET: CougYear/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cougYear = await _context.CougYear.FindAsync(id);
            if (cougYear == null)
            {
                return NotFound();
            }
            return View(cougYear);
        }

        // POST: CougYear/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Year")] CougYear cougYear)
        {
            if (id != cougYear.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cougYear);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CougYearExists(cougYear.Id))
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
            return View(cougYear);
        }

        // GET: CougYear/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cougYear = await _context.CougYear
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cougYear == null)
            {
                return NotFound();
            }

            return View(cougYear);
        }

        // POST: CougYear/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cougYear = await _context.CougYear.FindAsync(id);
            _context.CougYear.Remove(cougYear);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CougYearExists(int id)
        {
            return _context.CougYear.Any(e => e.Id == id);
        }
    }
}
