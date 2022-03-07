namespace AgendaCec.Models
{
    public class Pilar
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cor { get; set; }
        public string Slug { get; set; }

        public IList<Instrutor> Instrutores { get; set; }
        public IList<Area> Areas { get; set; }
    }
}