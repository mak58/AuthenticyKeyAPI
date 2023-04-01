using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChaveAutenticidadeSelos.Shared.Exceptions;

namespace ChaveAutenticidadeTest
{
    [TestClass]
    public class ChaveAutenticidadeTesteUnitario
    {
        [TestMethod]
        public void DeveRetornarExeçaoCasoListaChaveVazia()
        {
            var chaves = new List<string>();
            var exception = Assert.ThrowsException<ChaveAutenticidadeServicoExcecao>(()
                => ChaveAutenticidadeServicoExcecao.LancarExcecaoListaVaziaChaves(chaves));
                
            Assert.IsNotNull(exception);            
            Assert.AreEqual($"Lista de Chaves de Autenticidade não pode ser vazia", exception.Message);
        }

        [TestMethod]
        public void DeveRetornarExcecaoCasoTamanhoChaveIncorreto()
        {
            var chave = "ajsifjdijvivmvndfijfgijdi";
            var exception = Assert.ThrowsException<ChaveAutenticidadeServicoExcecao>(()
                => ChaveAutenticidadeServicoExcecao.LancarExcecaoTamanhoChaveAutenticidade(chave));
            
            Assert.IsNotNull(exception);
            Assert.AreEqual("Chave de Autenticidade Inválida!", exception.Message);
        }

        [TestMethod]
        public void DeveRetornarExcecaoCasoChaveNaoNumerica()
        {
            var chave = "d*tn&tN&wW&bAp!-oC#@v&";
            var exception = Assert.ThrowsException<ChaveAutenticidadeServicoExcecao>(()
                => ChaveAutenticidadeServicoExcecao.LancarExcecaoValidacaoChaveAutenticidade(chave));

            Assert.IsNotNull(exception);
            Assert.AreEqual("A Chave de Autenticidade deve conter somente números!", exception.Message);
        }

        [TestMethod]
        public void DeveRetornarExcecaoCasoChaveNaoEncontrada()
        {
            var arquivoHtml = "<h1>HelloWorld</h1>";
            var chave = string.Empty;
            var exception = Assert.ThrowsException<ChaveAutenticidadeServicoExcecao>(()
                => ChaveAutenticidadeServicoExcecao.LancarExcecaoChaveNaoEncontrada(chave, arquivoHtml));
            
            Assert.IsNotNull(exception);
            Assert.AreEqual($"Chave de Autenticidade {chave} não encontrada!", exception.Message);
        }
    }
}