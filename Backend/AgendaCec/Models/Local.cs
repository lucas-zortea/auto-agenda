namespace AgendaCec.Models
{
    public class Local
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Slug { get; set; }
        public bool Informatizada { get; set; }
        public int Capacidade { get; set; }
        public IList<Evento> Eventos { get; set; }
    }
}