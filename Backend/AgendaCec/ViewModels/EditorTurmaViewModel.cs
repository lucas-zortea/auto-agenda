using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace AgendaCec.Controllers
{
    public class EditorTurmaViewModel
    {
        [Required(ErrorMessage = "Nome da turma obrigatoria")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Apelido do instrutor é obrigatório")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "Apelido do instrutor é obrigatório")]
        public DateTime DataFim { get; set; }

        [Required(ErrorMessage = "Numero de alunos é obrigatório")]
        public int NumeroAlunos { get; set; }

        [Required(ErrorMessage = "Numero de alunos é obrigatório")]
        public IList Disciplinas { get; set; }

        [Required(ErrorMessage = "Numero de alunos é obrigatório")]
        public IList Eventos { get; set; }


    }
}