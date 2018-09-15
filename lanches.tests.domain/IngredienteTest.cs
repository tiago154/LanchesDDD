using lanches.domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace lanches.tests.domain
{
    [TestClass]
    public class IngredienteTest
    {
        private readonly Ingrediente _ingredienteSemValores;
        private readonly Ingrediente _ingredienteComValores;

        public IngredienteTest()
        {
            _ingredienteSemValores = new Ingrediente("", 0);
            _ingredienteComValores = new Ingrediente("Bacon", Convert.ToDecimal(1.75));
        }

        [TestMethod]
        public void NomeDeveRetornaStringVazia()
        {
            Assert.AreEqual("", _ingredienteSemValores.Nome);
        }

        [TestMethod]
        public void NomeDeveRetornaStringDoParametro()
        {
            Assert.AreEqual("Bacon", _ingredienteComValores.Nome);
        }

        [TestMethod]
        public void ValorDeveRetornaZero()
        {
            Assert.AreEqual(0, _ingredienteSemValores.Valor);
        }

        [TestMethod]
        public void ValorDeveEstarPreenchido()
        {
            Assert.AreEqual(Convert.ToDecimal(1.75), _ingredienteComValores.Valor);
        }
    }
}
