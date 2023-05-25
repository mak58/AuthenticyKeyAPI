using System.Text.RegularExpressions;
using ChaveAutenticidadeSelos.Core.Dto;
using ChaveAutenticidadeSelos.Services.Interfaces;
using ChaveAutenticidadeTjRs.Shared;
using OneOf;

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
        /// <returns> A class or a especific error. </returns>

        async Task<OneOf<List<DadosServentiaDto>, ListaVazia, ChaveInvalida, ChaveNaoNumerica, ChaveNulla>> 
            IChaveAutenticidadeService.ObterDadosChaveAutenticidade(List<string> chavesAutenticidade)
        {
            var client = _clientFactory.CreateClient(ClientName);

            string arquivoHTML;

            var dadosList = new List<DadosServentiaDto>();

            // if (chavesAutenticidade.Count == 0)
            //     return new ListaVazia();

            if (chavesAutenticidade.Count == 0)
                return new ListaVazia();
            {
                foreach (var item in chavesAutenticidade)
                {
                    if (item.Length != 22)
                        return new ChaveInvalida();

                    if (!Regex.IsMatch(item, @"^[0-9]+$"))
                        return new ChaveNaoNumerica();

                    arquivoHTML = await client.GetStringAsync($"consulta_selo_chave.php?c={item}");

                    if (!arquivoHTML.Contains("table"))
                        return new ChaveNulla();

                    dadosList.Add(_ExtrairInfo.ExtrairInformacoesChave(arquivoHTML));
                }

                return dadosList;
            }            
        }
    }
}