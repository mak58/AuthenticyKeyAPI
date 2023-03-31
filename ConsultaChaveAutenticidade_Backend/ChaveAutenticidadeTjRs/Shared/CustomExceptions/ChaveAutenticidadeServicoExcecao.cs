using System.Text.RegularExpressions;

namespace ChaveAutenticidadeSelos.Shared.Exceptions;

public class ChaveAutenticidadeServicoExcecao : Exception
{    
    public ChaveAutenticidadeServicoExcecao(string message = "Ops! Provavelmente sua chave de autenticidade é inválida")
        : base(message) {}

    public static void LancarExcecaoListaVaziaChaves(List<string> chaves)
    {
        if (chaves.Count == 0)
            throw new ChaveAutenticidadeServicoExcecao("Lista de Chaves de Autenticidade não pode ser vazia");
    }
    
    public static void LancarExcecaoTamanhoChaveAutenticidade(string chave)
    {
        if (chave.Length != 22)
            throw new ChaveAutenticidadeServicoExcecao("Chave de Autenticidade Inválida!");
    }

    public static void LancarExcecaoValidacaoChaveAutenticidade(string chave)
    {
        if (!Regex.IsMatch(chave, @"^[0-9]+$"))
            throw new ChaveAutenticidadeServicoExcecao("A Chave de Autenticidade deve conter somente números!");
    }
  
    public static void LancarExcecaoChaveNaoEncontrada(string chave, string arquivoHtml)
    {
        if (!arquivoHtml.Contains("table"))
            throw new ChaveAutenticidadeServicoExcecao($"Chave de Autenticidade {chave} não encontrada!");
    }
}