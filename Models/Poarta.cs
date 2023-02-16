namespace Proiect1.Models
{
    public class Poarta
    {
        public int ID { get; set; }
        public int Numar { get; set; }
        public int Terminal { get; set; }
        public ICollection<Zbor>? Zboruri { get; set; }
    }
}
