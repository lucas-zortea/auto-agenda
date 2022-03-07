namespace AgendaCec.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Slug { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFim { get; set; }

        public Instrutor Instrutor { get; set; }
        public Turma Turma { get; set; }
        public Local Local { get; set; }
        public Disciplina Disciplina { get; set; }
    }
}