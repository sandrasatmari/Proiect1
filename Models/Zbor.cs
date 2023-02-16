using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace Proiect1.Models
{
    public class Zbor
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataPlecare { get; set; }
        public int NrLocuri { get; set; }
        public int NrLocuriRezervate { get; set; }
        //public int Poarta { get; set; }
        public int OreIntarziere { get; set; }
        public int? Destinatie { get; set; }
        public Aeroport? Aeroport { get; set; }
        public int? PoartaID { get; set; }
        public Poarta? Poarta { get; set; }
        public ICollection<CompanieZbor>? CompaniiZbor { get; set; }
        

    }
}
