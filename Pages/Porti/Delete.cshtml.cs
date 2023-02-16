using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect1.Data;
using Proiect1.Models;

namespace Proiect1.Pages.Porti
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect1.Data.Proiect1Context _context;

        public DeleteModel(Proiect1.Data.Proiect1Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Poarta Poarta { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Poarta == null)
            {
                return NotFound();
            }

            var poarta = await _context.Poarta.FirstOrDefaultAsync(m => m.ID == id);

            if (poarta == null)
            {
                return NotFound();
            }
            else 
            {
                Poarta = poarta;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Poarta == null)
            {
                return NotFound();
            }
            var poarta = await _context.Poarta.FindAsync(id);

            if (poarta != null)
            {
                Poarta = poarta;
                _context.Poarta.Remove(Poarta);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
