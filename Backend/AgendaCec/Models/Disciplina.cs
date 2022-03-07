namespace AgendaCec.Models
{
    public class Disciplina
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Slug { get; set; }

        public Area Area { get; set; }


        public IList<Turma> Turmas { get; set; }
        public IList<Instrutor> Instrutores { get; set; }
        public IList<Evento> Eventos { get; set; }
    }
}