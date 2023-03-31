using ChaveAutenticidadeSelos.Core.Dto;
using ChaveAutenticidadeSelos.Services.Interfaces;
using ChaveAutenticidadeSelos.Shared.Exceptions;

namespace ChaveAutenticidadeSelos.Services
{
    public class ChaveAutenticidadeService : IChaveAutenticidadeService
    {
        private readonly IHttpClientFactory _clientFactory;

        private readonly IExtrairInformacoes _ExtrairInfo;

        private const string ClientName = "ConsultaAutenticidadeTjApi";

        public ChaveAutenticidadeService(IHttpClientFactory clientFactory, IExtrairInformacoes extrairInfo)
        {
            _clientFactory = clientFactory;
            _ExtrairInfo = extrairInfo;
        }

        /// <summary>
        /// Método responsável por validar informações da(s) chave(s) de autenticidade(s) e chamar o método para extratir todas as informações. 
        /// </summary>
        /// <param name="chavesAutenticidade"></param>
        /// <returns></returns>
        public async Task<List<DadosServentiaDto>> ObterDadosChaveAutenticidade(List<string> chavesAutenticidade)
        {
           var client = _clientFactory.CreateClient(ClientName);

           string arquivoHTML;

           var dadosList = new List<DadosServentiaDto>();
        
           ChaveAutenticidadeServicoExcecao.LancarExcecaoListaVaziaChaves(chavesAutenticidade);

           foreach (var item in chavesAutenticidade)
           {            
                ChaveAutenticidadeServicoExcecao.LancarExcecaoTamanhoChaveAutenticidade(item);

                ChaveAutenticidadeServicoExcecao.LancarExcecaoValidacaoChaveAutenticidade(item);          
            
                arquivoHTML = await client.GetStringAsync($"consulta_selo_chave.php?c={item}");

                ChaveAutenticidadeServicoExcecao.LancarExcecaoChaveNaoEncontrada(item, arquivoHTML);

                dadosList.Add(_ExtrairInfo.ExtrairInformacoesChave(arquivoHTML));
                
           } 

            return dadosList;            
        }
    }
}