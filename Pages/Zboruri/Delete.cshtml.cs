using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect1.Data;
using Proiect1.Models;

namespace Proiect1.Pages.Zboruri
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect1.Data.Proiect1Context _context;

        public DeleteModel(Proiect1.Data.Proiect1Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Zbor Zbor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Zbor == null)
            {
                return NotFound();
            }

            var zbor = await _context.Zbor.FirstOrDefaultAsync(m => m.Id == id);

            if (zbor == null)
            {
                return NotFound();
            }
            else 
            {
                Zbor = zbor;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Zbor == null)
            {
                return NotFound();
            }
            var zbor = await _context.Zbor.FindAsync(id);

            if (zbor != null)
            {
                Zbor = zbor;
                _context.Zbor.Remove(Zbor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
