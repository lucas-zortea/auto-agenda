using System.ComponentModel.DataAnnotations;
using AgendaCec.Models;

namespace AgendaCec.ViewModels
{
    public class EditorDisciplinaViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "A área é obrigatória")]
        public int AreaId { get; set; }
    }
}