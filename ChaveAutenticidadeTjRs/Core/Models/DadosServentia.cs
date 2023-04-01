namespace ChaveAutenticidadeSelos.Core.Models
{
    public class DadosServentia
    {
        public class DadosServentiaDto
    {
        public string? ServentiaNome { get; set; }

        public string? ServentiaEndereco { get; set; }

        public List<Selos>? Selos { get; set; }
    }
    }
}