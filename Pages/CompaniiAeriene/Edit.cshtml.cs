using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect1.Data;
using Proiect1.Models;

namespace Proiect1.Pages.CompaniiAeriene
{
    public class EditModel : PageModel
    {
        private readonly Proiect1.Data.Proiect1Context _context;

        public EditModel(Proiect1.Data.Proiect1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public CompanieAeriana CompanieAeriana { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CompanieAeriana == null)
            {
                return NotFound();
            }

            var companieaeriana =  await _context.CompanieAeriana.FirstOrDefaultAsync(m => m.ID == id);
            if (companieaeriana == null)
            {
                return NotFound();
            }
            CompanieAeriana = companieaeriana;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CompanieAeriana).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanieAerianaExists(CompanieAeriana.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CompanieAerianaExists(int id)
        {
          return _context.CompanieAeriana.Any(e => e.ID == id);
        }
    }
}
