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

namespace Proiect1.Pages.Porti
{
    public class EditModel : PageModel
    {
        private readonly Proiect1.Data.Proiect1Context _context;

        public EditModel(Proiect1.Data.Proiect1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Poarta Poarta { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Poarta == null)
            {
                return NotFound();
            }

            var poarta =  await _context.Poarta.FirstOrDefaultAsync(m => m.ID == id);
            if (poarta == null)
            {
                return NotFound();
            }
            //Poarta = poarta;
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

            _context.Attach(Poarta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoartaExists(Poarta.ID))
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

        private bool PoartaExists(int id)
        {
          return _context.Poarta.Any(e => e.ID == id);
        }
    }
}
