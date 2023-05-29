using ChaveAutenticidadeTjRs.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ChaveAutenticidadeTests
{
    [TestClass]
    public class ChaveAutenticadadeTesteUnitarioBoolean
    {
        [TestMethod]
        public void DeveRetornarTrueCasoListaChaveVazia()
        {
            List<string> chaves = new();
            bool testList = ChaveAutenticidadeServicoValidacao.VerificarListaVaziaChaves(chaves);

            Assert.IsTrue(testList);
        }

        [TestMethod]
        public void DeveRetornarTrueCasoTamanhoChaveIncorreto()
        {
            string chave = "ajsifjdijvivmvndfijfgijdi";
            bool testTamanho = ChaveAutenticidadeServicoValidacao.VerificarTamanhoChaveAutenticidade(chave);

            Assert.IsTrue(testTamanho);
        }
        

        [TestMethod]
        public void DeveRetornarTrueCasoChaveNaoNumerica()
        {
            string chave = "d*tn&tN&wW&bAp!-oC#@v&";
            bool testDigitos = ChaveAutenticidadeServicoValidacao.VerificarValidacaoChaveAutenticidade(chave);

            Assert.IsTrue(testDigitos);
        }

        [TestMethod]
        public void DeveRetornarTrueCasoChaveNaoEncontrada()
        {
            string chave = "<h1>HelloWorld</h1>";
            bool testNotFound = ChaveAutenticidadeServicoValidacao.VerificarChaveNaoEncontrada(chave);

            Assert.IsTrue(testNotFound);
        }
    }
}