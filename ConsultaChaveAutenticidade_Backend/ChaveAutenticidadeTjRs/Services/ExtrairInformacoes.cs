using HtmlAgilityPack;
using ChaveAutenticidadeSelos.Core.Dto;
using ChaveAutenticidadeSelos.Services.Interfaces; 


namespace ChaveAutenticidadeSelos.Services
{
    public class ExtrairInformacoes : IExtrairInformacoes
    {
        /// <summary>
        /// Método responsável por percorrer o html e extrair todos as informações solicitadas, como dados da serventia e dados do(s) selo(s).
        /// </summary>
        /// <param name="chaveArquivo"></param>
        /// <returns></returns>
        public DadosServentiaDto ExtrairInformacoesChave(string chaveArquivo)
        { 
            var chaveHtml = new HtmlDocument();
            var listaSelos = new List<SelosDto>();
            
           chaveHtml.LoadHtml(chaveArquivo);

           var documentTables = chaveHtml.DocumentNode.SelectNodes("//table").ToList();

           var serventia = new DadosServentiaDto
           {
               ServentiaNome = chaveHtml.DocumentNode.SelectSingleNode("//table[1]/tr[1]/td[1]").InnerText.Trim(),
               ServentiaEndereco = chaveHtml.DocumentNode.SelectSingleNode("//table[1]/tr[2]/td[1]").InnerText.Trim()               
           };

            for (var index = 2; index <= documentTables.Count; index++)
            {
                // Valor Emolumento e valor Avaliação
                var emolumento = chaveHtml.DocumentNode.SelectSingleNode("//table[" + index + "]/tr[6]/td[1]").InnerText.TrimStart();                       
                string valorAvaliacao = string.Empty;

                if (emolumento.Contains('/'))                                                    
                  valorAvaliacao = emolumento.Substring(emolumento.IndexOf('/') + 2).TrimEnd();                

                // Talão e número da NE
                var talaoNota = chaveHtml.DocumentNode.SelectSingleNode("//table[" + index + "]/tr[2]/td[1]").InnerText.Trim();
                string talao = string.Empty;
                string notaEntrega = string.Empty;

                if (talaoNota.Length > 1)
                {
                    talao = talaoNota.Substring(0, 1); 
                    notaEntrega = talaoNota.Substring(talaoNota.IndexOf('/') + 1);
                }

                listaSelos.Add(new SelosDto
                {
                    NumeroSelo = chaveHtml.DocumentNode.SelectSingleNode("//table[" + index + "]/tr[1]/td[1]").InnerText
                        .Replace("Selo Digital", "")
                        .Trim(),
                    Talao = talao,
                    NotaEntrega = notaEntrega,
                    DataEmissao = chaveHtml.DocumentNode.SelectSingleNode("//table[" + index + "]/tr[3]/td[1]").InnerText.Trim(),
                    Cobranca = chaveHtml.DocumentNode.SelectSingleNode("//table[" + index + "]/tr[4]/td[1]").InnerText.Trim(),
                    Ato = chaveHtml.DocumentNode.SelectSingleNode("//table[" + index + "]/tr[5]/td[1]").InnerText.Trim(),
                    Emolumento = emolumento.Substring(0, emolumento.IndexOf(" ")), 
                    ValorAvaliacao = valorAvaliacao,                 
                    ValorSelo = chaveHtml.DocumentNode.SelectSingleNode("//table[" + index + "]/tr[7]/td[1]").InnerText.Trim()
                        .Substring(18)
                    
                });
            }

            return new DadosServentiaDto()
            {
                ServentiaNome = serventia.ServentiaNome,
                ServentiaEndereco = serventia.ServentiaEndereco,                
                Selos = listaSelos
            };
        } 
        
    }
}
// Mentored by Giaretta H. ₢2023