using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Proiect1.Models
{
    public class Aeroport
    {
        public int ID { get; set; }

        [Display(Name = "Nume Aeroport")]
        public string Nume_Aeroport { get; set; }
        public ICollection<Zbor>? Zboruri { get; set; }

        public string Oras { get; set; }
        public string Tara { get; set; }
        
    }
}
