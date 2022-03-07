using System.ComponentModel.DataAnnotations;
using AgendaCec.Models;

namespace AgendaCec.ViewModels
{
    public class EditorInstrutorViewModel
    {
        [Required(ErrorMessage = "Nome do instrutor é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Apelido do instrutor é obrigatório")]
        public string Apelido { get; set; }

        [Required(ErrorMessage = "Email do instrutor é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Disponibilidade do instrutor é obrigatório")]
        public bool Disponivel { get; set; }

        public int PilarId { get; set; }
    }
}