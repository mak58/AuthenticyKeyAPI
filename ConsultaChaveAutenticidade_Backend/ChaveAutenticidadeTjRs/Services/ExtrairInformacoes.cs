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
        public DadosServentiaDto ExtrairInformacoesChave(string chaveArquivo, string chave)
        { 
            var chaveHtml = new HtmlDocument();
            var listaSelos = new List<SelosDto>();
            
           chaveHtml.LoadHtml(chaveArquivo);

           var documentTables = chaveHtml.DocumentNode.SelectNodes("//table").ToList();

           var serventia = new DadosServentiaDto
           {
               ChaveAutenticidade = chave,   
               ServentiaNome = chaveHtml.DocumentNode.SelectSingleNode("//table[1]/tr[1]/td[1]").InnerText.Trim(),
               ServentiaEndereco = chaveHtml.DocumentNode.SelectSingleNode("//table[1]/tr[2]/td[1]").InnerText.Trim()               
           };

            for (var index = 2; index <= documentTables.Count; index++)
            {
                string cobranca = chaveHtml.DocumentNode.SelectSingleNode("//table[" + index + "]/tr[4]/td[1]").InnerText.Trim();

                // Valor Emolumento
                var emolumento = chaveHtml.DocumentNode.SelectSingleNode("//table[" + index + "]/tr[6]/td[1]").InnerText.TrimStart();                                       

                //  Valor Avaliação
                var valorAvaliacao = 0M;

                if (emolumento.Contains('/')) 
                    valorAvaliacao = decimal.Parse(emolumento.Substring(emolumento.IndexOf('/') + 4).TrimEnd());                                                              
                            
                // Talão e número da NE
                var talaoNota = chaveHtml.DocumentNode.SelectSingleNode("//table[" + index + "]/tr[2]/td[1]").InnerText.Trim();
                string talao = string.Empty;
                string notaEntrega = string.Empty;

                if (talaoNota.Length > 1)
                {
                    talao = talaoNota.Substring(0, 1); 
                    notaEntrega = talaoNota.Substring(talaoNota.IndexOf('/') + 1);
                }            
                
                var valorSelo = decimal.Parse(chaveHtml.DocumentNode.SelectSingleNode("//table[" + index + "]/tr[7]/td[1]").InnerText.Trim().Substring(20));                                            

                listaSelos.Add(new SelosDto
                {
                    NumeroSelo = chaveHtml.DocumentNode.SelectSingleNode("//table[" + index + "]/tr[1]/td[1]").InnerText
                        .Replace("Selo Digital", "")
                        .Trim(),
                    Talao = talao,
                    NotaEntrega = int.Parse(notaEntrega),
                    DataEmissao = DateTime.Parse(chaveHtml.DocumentNode.SelectSingleNode("//table[" + index + "]/tr[3]/td[1]").InnerText.Trim()),
                    Cobranca = (cobranca.Contains("Sim")? true : false),
                    Ato = chaveHtml.DocumentNode.SelectSingleNode("//table[" + index + "]/tr[5]/td[1]").InnerText.Trim(),
                    Emolumento = decimal.Parse(emolumento.Substring(2, emolumento.IndexOf(" "))), 
                    ValorAvaliacao = valorAvaliacao,                 
                    ValorSelo = valorSelo
                    
                });
            }

            return new DadosServentiaDto()
            {
                ChaveAutenticidade = serventia.ChaveAutenticidade,
                ServentiaNome = serventia.ServentiaNome,
                ServentiaEndereco = serventia.ServentiaEndereco,                
                Selos = listaSelos
            };
        } 
        
    }
}
// Mentored by Giaretta H. ₢2023