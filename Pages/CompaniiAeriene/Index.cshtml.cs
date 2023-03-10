using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect1.Data;
using Proiect1.Models;
using Proiect1.Models.ViewModels;

namespace Proiect1.Pages.CompaniiAeriene
{
    public class IndexModel : PageModel
    {
        private readonly Proiect1.Data.Proiect1Context _context;

        public IndexModel(Proiect1.Data.Proiect1Context context)
        {
            _context = context;
        }

        public IList<CompanieAeriana> CompanieAeriana { get; set; } = default!;

        
        public async Task OnGetAsync()
        {
            if (_context.CompanieAeriana != null)
            {
                CompanieAeriana = await _context.CompanieAeriana.ToListAsync();
            }
        }
    }
}
