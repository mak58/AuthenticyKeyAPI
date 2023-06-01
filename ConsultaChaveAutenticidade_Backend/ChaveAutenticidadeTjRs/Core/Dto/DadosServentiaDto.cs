namespace ChaveAutenticidadeSelos.Core.Dto
{
    public class DadosServentiaDto
    {                
        public string? ChaveAutenticidade { get; set; }
        
        public string? ServentiaNome { get; set; }

        public string? ServentiaEndereco { get; set; }

        public List<SelosDto>? Selos { get; set; }
    }
}