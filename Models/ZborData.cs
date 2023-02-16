namespace Proiect1.Models
{
    public class ZborData
    {
        public IEnumerable<Zbor> Zboruri { get; set; }
        public IEnumerable<CompanieAeriana> CompaniiAeriene { get; set; }
        public IEnumerable<CompanieZbor> CompaniiZbor { get; set; }
    }
}
