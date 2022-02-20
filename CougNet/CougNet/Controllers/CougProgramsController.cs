﻿using System;
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
    public class CougProgramsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CougProgramsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CougPrograms
        public async Task<IActionResult> Index()
        {
            var progs = new List<CougProgram>();
            if (User.IsInRole("Admin")) {
                progs =  await _context.CougProgram.ToListAsync();
            }
            else
            {
                progs = await _context.CougProgram.Where(x => x.CreatedBy == User.Identity.Name).ToListAsync();
            }
            return View(progs);
        }

        // GET: CougPrograms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cougProgram = await _context.CougProgram
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cougProgram == null)
            {
                return NotFound();
            }

            return View(cougProgram);
        }

        // GET: CougPrograms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CougPrograms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CougProgram cougProgram)
        {
            if (ModelState.IsValid)
            {
                cougProgram.CreatedBy = User.Identity.Name;
                _context.Add(cougProgram);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cougProgram);
        }

        // GET: CougPrograms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cougProgram = await _context.CougProgram.FindAsync(id);
            if (cougProgram == null)
            {
                return NotFound();
            }
            return View(cougProgram);
        }

        // POST: CougPrograms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CougProgram cougProgram)
        {
            if (id != cougProgram.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (string.IsNullOrEmpty(cougProgram.CreatedBy))
                    {
                        cougProgram.CreatedBy = User.Identity.Name; //temp fix for blank created bys
                    }
                    _context.Update(cougProgram);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CougProgramExists(cougProgram.Id))
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
            return View(cougProgram);
        }

        // GET: CougPrograms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cougProgram = await _context.CougProgram
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cougProgram == null)
            {
                return NotFound();
            }

            return View(cougProgram);
        }

        // POST: CougPrograms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cougProgram = await _context.CougProgram.FindAsync(id);
            _context.CougProgram.Remove(cougProgram);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: CougPrograms/Register/5
        public async Task<IActionResult> Register(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cougProgram = await _context.CougProgram
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cougProgram == null)
            {
                return NotFound();
            }

            cougProgram.IsRegistered = (_context.CougProgramRegistrations
                .FirstOrDefault(x => x.Coug.AppId == User.Identity.Name && x.CougProgram.Id == cougProgram.Id) != null);

            return View(cougProgram);
        }

        // POST: CougPrograms/Register/5
        [HttpPost, ActionName("Register")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterConfirmed(int id)
        {
            var cougProgram = await _context.CougProgram.FindAsync(id);
            var coug = await _context.Coug.Where(x => x.AppId == User.Identity.Name).FirstOrDefaultAsync();
            if (coug == null)
            {
                //create a dummy coug for the person
                coug = new Coug { AppId = User.Identity.Name };
                _context.Coug.Add(coug);
            }
            // check if already registered
            if (_context.CougProgramRegistrations.FirstOrDefault(x => x.Coug.Id == coug.Id && x.CougProgram.Id == cougProgram.Id) == null)
            {
                _context.CougProgramRegistrations.Add(new CougProgramRegistration
                {
                    Coug = coug,
                    CougProgram = cougProgram
                });
            }
            await _context.SaveChangesAsync();

            cougProgram.IsRegistered = true;

            return View(cougProgram);
            //return RedirectToAction(nameof(Index));
        }

        // GET: CougPrograms/Unregister/5 - used to unregister for the program
        
        public async Task<IActionResult> Unregister(int id)
        {
            var cougProgram = await _context.CougProgram.FindAsync(id);
            var coug = await _context.Coug.Where(x => x.AppId == User.Identity.Name).FirstOrDefaultAsync();

            var reg = _context.CougProgramRegistrations.FirstOrDefault(x => x.Coug.Id == coug.Id && x.CougProgram.Id == cougProgram.Id);
            if (reg != null)
            {
                _context.CougProgramRegistrations.Remove(reg);
                _context.SaveChanges();
            }

            cougProgram.IsRegistered = false;
            return RedirectToAction("Register", new { id = id });
        }

        private bool CougProgramExists(int id)
        {
            return _context.CougProgram.Any(e => e.Id == id);
        }
    }
}
