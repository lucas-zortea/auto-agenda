namespace AgendaCec.Models
{
    public class Instrutor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Slug { get; set; }
        public string Apelido { get; set; }
        public string Email { get; set; }
        public bool Disponivel { get; set; }

        public int PilarId { get; set; }

        public Pilar Pilar { get; set; }
        public IList<Disciplina> Disciplinas { get; set; }
        public IList<Evento> Eventos { get; set; }
    }
}