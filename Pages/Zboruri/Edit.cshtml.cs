using
 System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect1.Data;
using Proiect1.Models;

namespace Proiect1.Pages.Zboruri
{
    public class EditModel : CompaniiZborPageModel
    {
        private readonly Proiect1.Data.Proiect1Context _context;

        public EditModel(Proiect1.Data.Proiect1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Zbor Zbor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Zbor == null)
            {
                return NotFound();
            }
            Zbor = await _context.Zbor
                .Include(b => b.Aeroport)
                .Include(b => b.CompaniiZbor).ThenInclude(b => b.CompanieAeriana)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            //var zbor =  await _context.Zbor.FirstOrDefaultAsync(m => m.Id == id);
            if (Zbor == null)
            {
                return NotFound();
            }
            PopulateAssignedAirlineData(_context, Zbor);

            //Zbor = zbor;
            ViewData["Destinatie"] = new SelectList(_context.Set<Aeroport>(), "ID", "Nume_Aeroport");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedAirlines)
        {
            if (id == null)
            {
                return NotFound();
            }
            var zborToUpdate = await _context.Zbor
            .Include(i => i.Aeroport)
            .Include(i => i.CompaniiZbor)
            .ThenInclude(i => i.CompanieAeriana)
            .FirstOrDefaultAsync(s => s.Id == id);
            if (zborToUpdate == null)
            {
                return NotFound();
            }
            
            if (await TryUpdateModelAsync<Zbor>(
            zborToUpdate,
            "Zbor",
            i => i.DataPlecare, i => i.NrLocuri,
            i => i.NrLocuriRezervate, i => i.Poarta, i => i.OreIntarziere, i => i.Destinatie))
            {
                UpdateCompaniiZbor(_context, selectedAirlines, zborToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateCompaniiZbor(_context, selectedAirlines, zborToUpdate);
            PopulateAssignedAirlineData(_context, zborToUpdate);
            return Page();

        }


    }
}