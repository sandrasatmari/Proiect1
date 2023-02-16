namespace Proiect1.Models
{
    public class CompanieZbor
    {
        public int Id { get; set; }
        public int? ZborID { get; set; }
        public Zbor? Zbor { get; set; }

        public int CompanieAerianaID { get; set; }
        public CompanieAeriana? CompanieAeriana { get; set; }

    }
}
