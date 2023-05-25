using System.Text.RegularExpressions;

namespace ChaveAutenticidadeTjRs.Shared;

public static class ChaveAutenticidadeServicoValidacao //: IChaveAutenticidadeServicoValidacao
{

    public static bool VerificarListaVaziaChaves(List<string> chaves)
    {
        if (chaves.Count == 0) 
            return true;
        else
            return false;
         //("Lista de Chaves de Autenticidade não pode ser vazia");
    }

    public static bool VerificarTamanhoChaveAutenticidade(string chave)
    {
        if (chave.Length != 22) {}
            return false; //("Chave de Autenticidade Inválida!");
    }

    public static bool VerificarValidacaoChaveAutenticidade(string chave)
    {
        if (!Regex.IsMatch(chave, @"^[0-9]+$")) {}
            return false; //("A Chave de Autenticidade deve conter somente números!");
    }

    public static bool VerificarChaveNaoEncontrada(string chave, string arquivoHtml)
    {
        if (!arquivoHtml.Contains("table")) {}
            return false; //($"Chave de Autenticidade {chave} não encontrada!");
    }
}