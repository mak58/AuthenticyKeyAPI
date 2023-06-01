namespace ChaveAutenticidadeSelos.Core.Models
{
    public class Selos
    {
        public string? NumeroSelo { get; set; }

        public string? Talao { get; set; }

        public int NotaEntrega { get; set; }

        public DateTime DataEmissao { get; set; }

        public bool Cobranca { get; set; }        

        public string? Ato { get; set; } 

        public decimal Emolumento { get; set; }

        public decimal ValorSelo { get; set; }

        public decimal ValorAvaliacao { get; set; }
    }
}