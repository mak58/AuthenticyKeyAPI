using System.Text.RegularExpressions;

namespace ChaveAutenticidadeTjRs.Shared;

public static class ChaveAutenticidadeServicoValidacao //: IChaveAutenticidadeServicoValidacao
{
    public static bool VerificarListaVaziaChaves(List<string> chaves)
    {
        bool result = (chaves.Count == 0) ? true : false;
            return result;

         //("Lista de Chaves de Autenticidade não pode ser vazia");
    }

    public static bool VerificarTamanhoChaveAutenticidade(string chave)
    {
        bool result = (chave.Length != 22) ? true : false;
            return result; 
            
        //("Chave de Autenticidade Inválida!");
    }

    public static bool VerificarValidacaoChaveAutenticidade(string chave)
    {
        bool result = (!Regex.IsMatch(chave, @"^[0-9]+$")) ? true : false;
            return result; 
        
        //("A Chave de Autenticidade deve conter somente números!");
    }

    public static bool VerificarChaveNaoEncontrada(string arquivoHtml)
    {
        bool result = (!arquivoHtml.Contains("table")) ? true : false;
            return result; 
        
        //($"Chave de Autenticidade {chave} não encontrada!");
    }
}