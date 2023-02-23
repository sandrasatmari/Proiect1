using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect1.Models;
using Proiect1.Models.ViewModels;

namespace Proiect1.Pages.Aeroporturi
{
    public class IndexModel : PageModel
    {
        private readonly Proiect1.Data.Proiect1Context _context;

        public IndexModel(Proiect1.Data.Proiect1Context context)
        {
            _context = context;
        }

        public IList<Aeroport> Aeroport { get; set; } = default!;
        public AeroportIndexData AeroportData { get; set; }
        public int AeroportID { get; set; }
        public int ZborID { get; set; }
        public async Task OnGetAsync(int? id, int? zborID)
        {
            AeroportData = new AeroportIndexData();
            AeroportData.Aeroporturi = await _context.Aeroport
                .Include(i => i.Zboruri)
                .ThenInclude(c => c.Poarta)
                .OrderBy(i => i.Nume_Aeroport)
                .ToListAsync();

            if (id != null)
            {
                AeroportID = id.Value;
                Aeroport aeroport = AeroportData.Aeroporturi
                    .Where(i => i.ID == id.Value).Single();
                AeroportData.Zboruri = aeroport.Zboruri;
            }
        }
    }
}
