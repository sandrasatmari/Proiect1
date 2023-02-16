using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect1.Data;
using Proiect1.Models;

namespace Proiect1.Pages.Zboruri
{
    public class CreateModel : CompaniiZborPageModel
    {
        private readonly Proiect1.Data.Proiect1Context _context;

        public CreateModel(Proiect1.Data.Proiect1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["Destinatie"] = new SelectList(_context.Set<Aeroport>(), "ID", "Nume_Aeroport");
            ViewData["PoartaID"] = new SelectList(_context.Set<Poarta>(), "ID", "Numar");
            var zbor = new Zbor();
            zbor.CompaniiZbor = new List<CompanieZbor>();
            PopulateAssignedAirlineData(_context, zbor);
            return Page();
        }

        [BindProperty]
        public Zbor Zbor { get; set; }
        public int CompanieAerianaID { get; private set; }


        // To protect from overposting attacks, seehttps://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedAirlines)
        {
            //var newCompanieZbor = new CompanieZbor();
            var newZbor = Zbor;
            if (selectedAirlines != null)
            {
                newZbor.CompaniiZbor = new List<CompanieZbor>();
                foreach (var comp in selectedAirlines)
                {
                    var compToAdd = new CompanieZbor
                    {
                        CompanieAerianaID = int.Parse(comp)
                    };
                    newZbor.CompaniiZbor.Add(compToAdd);
                }
            }
            //Zbor.CompaniiZbor = newZbor.CompaniiZbor;
            _context.Zbor.Add(Zbor);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

            PopulateAssignedAirlineData(_context, newZbor);
            return Page();
        }
    }

}

