namespace ChaveAutenticidadeTjRs.Core.Models
{
    public static class Errors
    {
        public static readonly Error ChaveInvalida = new Error("ChaveInvalida", "Chave de Autenticidade Inválida, Verifique a quantidade de Dígitos!");
        public static readonly Error ListaVazia = new Error("ListaVazia", "Lista de Chaves de Autenticidade não pode ser vazia!");
        public static readonly Error ChaveNaoNumerica = new Error("ChaveNaoNumerica", "A Chave de Autenticidade deve conter somente números!");
        public static readonly Error ChaveNulla = new Error("ChaveNulla", "Chave de Autenticidade não encontrada!");
    }
}