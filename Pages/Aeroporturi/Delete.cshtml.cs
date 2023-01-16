using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect1.Data;
using Proiect1.Models;

namespace Proiect1.Pages.Aeroporturi
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect1.Data.Proiect1Context _context;

        public DeleteModel(Proiect1.Data.Proiect1Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Aeroport Aeroport { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Aeroport == null)
            {
                return NotFound();
            }

            var aeroport = await _context.Aeroport.FirstOrDefaultAsync(m => m.ID == id);

            if (aeroport == null)
            {
                return NotFound();
            }
            else 
            {
                Aeroport = aeroport;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Aeroport == null)
            {
                return NotFound();
            }
            var aeroport = await _context.Aeroport.FindAsync(id);

            if (aeroport != null)
            {
                Aeroport = aeroport;
                _context.Aeroport.Remove(Aeroport);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
