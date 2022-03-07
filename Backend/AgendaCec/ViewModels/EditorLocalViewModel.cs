using System.ComponentModel.DataAnnotations;

namespace AgendaCec.ViewModels
{
    public class EditorLocalViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informatizada é obrigatório")]
        public bool Informatizada { get; set; }

        [Required(ErrorMessage = "Capacidade é obrigatório")]
        public int Capacidade { get; set; }
    }
}