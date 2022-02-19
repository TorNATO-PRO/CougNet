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
    public class CougCourseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CougCourseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CougCourse
        public async Task<IActionResult> Index()
        {
            return View(await _context.CougCourse.ToListAsync());
        }

        // GET: CougCourse/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cougCourse = await _context.CougCourse
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cougCourse == null)
            {
                return NotFound();
            }

            return View(cougCourse);
        }

        // GET: CougCourse/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CougCourse/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] CougCourse cougCourse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cougCourse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cougCourse);
        }

        // GET: CougCourse/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cougCourse = await _context.CougCourse.FindAsync(id);
            if (cougCourse == null)
            {
                return NotFound();
            }
            return View(cougCourse);
        }

        // POST: CougCourse/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] CougCourse cougCourse)
        {
            if (id != cougCourse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cougCourse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CougCourseExists(cougCourse.Id))
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
            return View(cougCourse);
        }

        // GET: CougCourse/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cougCourse = await _context.CougCourse
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cougCourse == null)
            {
                return NotFound();
            }

            return View(cougCourse);
        }

        // POST: CougCourse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cougCourse = await _context.CougCourse.FindAsync(id);
            _context.CougCourse.Remove(cougCourse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CougCourseExists(int id)
        {
            return _context.CougCourse.Any(e => e.Id == id);
        }
    }
}
