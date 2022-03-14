namespace AgendaCec.Models
{
    public class Area
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Slug { get; set; }
        public int PilarId { get; set; }


        public Pilar Pilar { get; set; }
        public IList<Disciplina> Disciplinas { get; set; }
        public IList<Evento> Eventos { get; set; }
    }
}