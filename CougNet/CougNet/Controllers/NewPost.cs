using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CougModels;
using CougNet.Data;

namespace CougNet.Views.CougPrograms
{
    public class _NewPostModel : PageModel
    {
        private readonly CougNet.Data.ApplicationDbContext _context;

        public _NewPostModel(CougNet.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Discussion Discussion { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Discussions.Add(Discussion);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
