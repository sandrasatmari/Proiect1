using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect1.Data;
using Proiect1.Models;

namespace Proiect1.Pages.CompaniiAeriene
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect1.Data.Proiect1Context _context;

        public DetailsModel(Proiect1.Data.Proiect1Context context)
        {
            _context = context;
        }

      public CompanieAeriana CompanieAeriana { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CompanieAeriana == null)
            {
                return NotFound();
            }

            var companieaeriana = await _context.CompanieAeriana.FirstOrDefaultAsync(m => m.ID == id);
            if (companieaeriana == null)
            {
                return NotFound();
            }
            else 
            {
                CompanieAeriana = companieaeriana;
            }
            return Page();
        }
    }
}
