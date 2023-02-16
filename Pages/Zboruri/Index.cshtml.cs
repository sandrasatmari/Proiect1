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
    public class IndexModel : PageModel
    {
        private readonly Proiect1.Data.Proiect1Context _context;

        public IndexModel(Proiect1.Data.Proiect1Context context)
        {
            _context = context;
        }

        public IList<Zbor> Zbor { get; set; } = default!;
        public ZborData ZborD { get; set; }
        public int ZborID { get; set; }
        public int CompanieAerianaID { get; set; }

        public string DestinatieSort { get; set; }
        public string PoartaSort { get; set; }
        public string CurrentFilter { get; set; }


        public async Task OnGetAsync(int? id, int? CompanieAerianaID, string sortOrder, string searchString)
        {
            ZborD = new ZborData();

            DestinatieSort = String.IsNullOrEmpty(sortOrder) ? "destinatie_desc" : "";
            PoartaSort = String.IsNullOrEmpty(sortOrder) ? "poarta_desc" : "";
            CurrentFilter = searchString;


            ZborD.Zboruri = await _context.Zbor
            .Include(b => b.Aeroport)
            .Include(b => b.CompaniiZbor)
            .ThenInclude(b => b.CompanieAeriana)
            .AsNoTracking()
            .OrderBy(b => b.Destinatie)
            .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                ZborD.Zboruri = ZborD.Zboruri.Where(s => s.PoartaID.ToString().Contains(searchString)

               || s.Destinatie.ToString().Contains(searchString));
            }

            if (id != null)
            {
                ZborID = id.Value;
                Zbor zbor = ZborD.Zboruri
                .Where(i => i.Id == id.Value).Single();
                ZborD.CompaniiAeriene = zbor.CompaniiZbor.Select(s => s.CompanieAeriana);
            }
            switch (sortOrder)
            {
                case "destinatie_desc":
                    ZborD.Zboruri = ZborD.Zboruri.OrderByDescending(s => s.Destinatie.ToString());
                    break;
                case "poarta_desc":
                    ZborD.Zboruri = ZborD.Zboruri.OrderByDescending(s => s.PoartaID.ToString());
                    break;
            }



        }
    }
}
