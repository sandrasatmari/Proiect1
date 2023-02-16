using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Xml.Linq;

namespace Proiect1.Models
{
    public class CompanieAeriana
    {
        public int ID { get; set; }
        [Display(Name = "Nume Companie")]
        public string Nume_Airline { get; set; }
        public string Tara { get; set; }
        public string CallCenter { get; set; }

        public string EmailContact { get; set; }
        public ICollection<CompanieZbor>? CompaniiZbor { get; set; }
        public int? MemberID { get; set; }
        public Member? Members { get; set; }


    }
}
