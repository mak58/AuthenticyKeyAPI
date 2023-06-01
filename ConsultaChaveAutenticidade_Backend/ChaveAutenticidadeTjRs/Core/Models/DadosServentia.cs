namespace ChaveAutenticidadeSelos.Core.Models
{
    public class DadosServentia
    {        
        public string? ChaveAutenticidade { get; set; }

        public string? ServentiaNome { get; set; }

        public string? ServentiaEndereco { get; set; }

        public List<Selos>? Selos { get; set; }
    }
}