using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect1.Data;
namespace Proiect1.Models
{
    public class CompaniiZborPageModel:PageModel
    {
        public List<AssignedAirlineData> AssignedAirlineDataList;
        public void PopulateAssignedAirlineData(Proiect1Context context, Zbor zbor)
        {
            var allCompaniiAeriene = context.CompanieAeriana;
            var companiiZbor = new HashSet<int>(
                zbor.CompaniiZbor.Select(c => c.CompanieAerianaID)); 
            AssignedAirlineDataList = new List<AssignedAirlineData>();
            foreach (var comp in allCompaniiAeriene)
            {
                AssignedAirlineDataList.Add(new AssignedAirlineData
                {
                    CompanieAerianaID = comp.ID,
                    AirlineName = comp.Nume_Airline,
                    Assigned = companiiZbor.Contains(comp.ID)
                });
            }
        }
        public void UpdateCompaniiZbor(Proiect1Context context,
        string[] selectedAirlines, Zbor zborToUpdate)
        {
            if (selectedAirlines == null)
            {
                zborToUpdate.CompaniiZbor = new List<CompanieZbor>();
                return;
            }
            var selectedAirlinesHS = new HashSet<string>(selectedAirlines);
            var companiiZbor = new HashSet<int>
            (zborToUpdate.CompaniiZbor.Select(c => c.CompanieAeriana.ID));
            foreach (var comp in context.CompanieAeriana)
            {
                if (selectedAirlinesHS.Contains(comp.ID.ToString()))
                {
                    if (!companiiZbor.Contains(comp.ID))
                    {
                        zborToUpdate.CompaniiZbor.Add(
                        new CompanieZbor
                        {
                            ZborID = zborToUpdate.Id,
                            CompanieAerianaID = comp.ID
                        });
                    }
                }
                else
                {
                    if (companiiZbor.Contains(comp.ID))
                    {
                        CompanieZbor courseToRemove
                            = zborToUpdate
                                .CompaniiZbor
                                .SingleOrDefault(i => i.CompanieAerianaID == comp.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }

}
