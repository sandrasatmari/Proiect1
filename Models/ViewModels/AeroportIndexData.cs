using Proiect1.Models;
namespace Proiect1.Models.ViewModels
{
    public class AeroportIndexData
    {
            public IEnumerable<Aeroport> Aeroporturi { get; set; }
            public IEnumerable<Zbor> Zboruri { get; set; }

    }
}
