using ChaveAutenticidadeSelos.Core.Dto;
using OneOf;

namespace ChaveAutenticidadeSelos.Services.Interfaces
{
    public interface IChaveAutenticidadeService
    {
        Task<OneOf<List<DadosServentiaDto>, ListaVazia, ChaveInvalida, ChaveNaoNumerica, ChaveNulla>> ObterDadosChaveAutenticidade(List<string>chavesAutenticidade);
    }
}