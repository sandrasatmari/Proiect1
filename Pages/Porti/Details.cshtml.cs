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
    public class DetailsModel : PageModel
    {
        private readonly Proiect1.Data.Proiect1Context _context;

        public DetailsModel(Proiect1.Data.Proiect1Context context)
        {
            _context = context;
        }

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
    }
}
