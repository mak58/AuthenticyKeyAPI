namespace ChaveAutenticidadeSelos.Core.Dto
{
    public class SelosDto
    {
        public string? NumeroSelo { get; set; }

        public string Talao { get; set; }

        public int? NotaEntrega { get; set; }

         public DateTime DataEmissao { get; set; }

        public bool Cobranca { get; set; } 

        public string? Ato { get; set; }      

        public Decimal Emolumento { get; set; }

        public Decimal ValorSelo { get; set; }

        public Decimal ValorAvaliacao { get; set; }
    
    }
}