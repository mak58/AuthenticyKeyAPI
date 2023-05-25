using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ChaveAutenticidadeTjRs.Core.Requests
{
    public class ListaChavesRequest
    {
        [Required(ErrorMessage = "Deve conter ao menos uma chave de autenticidade para consulta.")]
        [StringLength(22, MinimumLength = 22, ErrorMessage = " Chave inválida. Verefique sua chave.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = " Chave deve conter somente números.")]

        public List<string> ChavesAutenticidade { get; set; }        
    }
}