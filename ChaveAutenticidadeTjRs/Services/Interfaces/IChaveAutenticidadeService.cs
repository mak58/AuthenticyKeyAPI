using ChaveAutenticidadeSelos.Core.Dto;

namespace ChaveAutenticidadeSelos.Services.Interfaces
{
    public interface IChaveAutenticidadeService
    {
         Task<List<DadosServentiaDto>> ObterDadosChaveAutenticidade(List<string>chaveAutenticidade);
    }
}