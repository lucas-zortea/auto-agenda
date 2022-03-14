namespace AgendaCec.Models
{
    public class Turma
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Slug { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int NumeroAlunos { get; set; }

        public IList<Disciplina> Disciplinas { get; set; }
        public IList<Evento> Eventos { get; set; }


    }
}