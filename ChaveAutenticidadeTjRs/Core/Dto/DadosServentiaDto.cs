using System.ComponentModel.DataAnnotations;


namespace ChaveAutenticidadeSelos.Core.Dto
{
    public class DadosServentiaDto
    {
        [Required]
        public string? ServentiaNome { get; set; }

        [Required]
        public string? ServentiaEndereco { get; set; }

        [Required]
        public List<SelosDto>? Selos { get; set; }
    }
}