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
    public class CougsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CougsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cougs
        public async Task<IActionResult> Index()
        { 
            var appID = User.Identity.Name;

            // Check if the person has a profile already
            var cougProfile = _context.Coug
                .Include(x => x.Gender)
                .Include(x => x.Year)
                .Include(x => x.Major)
                .Where(x => x.AppId == appID).FirstOrDefault();

            if (cougProfile == null)
            {
                cougProfile = new Coug();
            }

            return View(cougProfile);
        }

        // GET: Cougs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coug = await _context.Coug
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coug == null)
            {
                return NotFound();
            }

            return View(coug);
        }

        // GET: Cougs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cougs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Firstname,Lastname")] Coug coug)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coug);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coug);
        }

        // GET: Cougs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var appID = User.Identity.Name;

            if (id == null)
            {
                return NotFound();
            }

            var coug = await _context.Coug.FindAsync(id);
            if (coug == null)
            {
                return NotFound();
            }
            return View(coug);
        }

        // POST: Cougs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Firstname,Lastname")] Coug coug)
        {
            if (id != coug.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coug);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CougExists(coug.Id))
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
            return View(coug);
        }

        // GET: Cougs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coug = await _context.Coug
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coug == null)
            {
                return NotFound();
            }

            return View(coug);
        }

        // POST: Cougs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coug = await _context.Coug.FindAsync(id);
            _context.Coug.Remove(coug);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CougExists(int id)
        {
            return _context.Coug.Any(e => e.Id == id);
        }
    }
}