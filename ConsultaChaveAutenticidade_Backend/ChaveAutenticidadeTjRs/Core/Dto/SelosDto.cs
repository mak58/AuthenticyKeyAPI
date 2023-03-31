using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChaveAutenticidadeSelos.Core.Dto
{
    public class SelosDto
    {
        public string? NumeroSelo { get; set; }

        public string? Talao { get; set; }

        public string? NotaEntrega { get; set; }

         public string? DataEmissao { get; set; }

        public string? Cobranca { get; set; } 

        public string? Ato { get; set; }      

        public string? Emolumento { get; set; }

        public string? ValorSelo { get; set; }

        public string? ValorAvaliacao { get; set; } = string.Empty;
    
    }
}