using ChaveAutenticidadeSelos.Core.Dto;

namespace ChaveAutenticidadeSelos.Services.Interfaces
{
    public interface IExtrairInformacoes
    {
        public DadosServentiaDto ExtrairInformacoesChave(string chaveArquivo, string chave);
    }
}