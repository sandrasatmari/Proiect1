﻿using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect1.Models;

namespace Proiect1.Pages.Members
{
    public class IndexModel : PageModel
    {
        private readonly Proiect1.Data.Proiect1Context _context;

        public IndexModel(Proiect1.Data.Proiect1Context context)
        {
            _context = context;
        }

        public IList<Member> Member { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Member != null)
            {
                Member = await _context.Member
                    .Include(b => b.CompanieAeriana)
                    .ToListAsync();
            }
        }
    }
}
