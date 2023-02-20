using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Proiect1.Models
{
    public class Member
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Adress { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        [Display(Name = "Full Name")]
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        //public CompanieAeriana companieAeriana { get; set; }

        public int? CompanieAerianaID { get; set; }
        public CompanieAeriana? CompanieAeriana { get; set; }
    }
}
