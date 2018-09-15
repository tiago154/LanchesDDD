using lanches.domain.Entities;
using lanches.domain.Resources;
using lanches.domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace lanches.tests.domain
{
    [TestClass]
    public class LancheTest
    {
        private readonly Lanche _lancheValido;
        private readonly Lanche _lancheInvalido;
        private readonly List<Ingrediente> _ingredientes;


        public LancheTest()
        {
            _ingredientes = new List<Ingrediente>
            {
                new Ingrediente("Ingrediente1", Convert.ToDecimal(1.50)),
                new Ingrediente("Ingrediente2", Convert.ToDecimal(0.75)),
                new Ingrediente("Ingrediente3", Convert.ToDecimal(2))
            };

            _lancheValido = new Lanche("LancheTeste", _ingredientes, Convert.ToDecimal(5.50));
            _lancheInvalido = new Lanche("Lanc", new List<Ingrediente>(), 0);
        }

        [TestMethod]
        public void DeveConterIngredientes()
        {
            Assert.AreEqual(3, _lancheValido.Ingredientes.Count);
        }

        [TestMethod]
        public void NaoDeveConterIngredientes()
        {
            Assert.AreEqual(0, _lancheInvalido.Ingredientes.Count);
        }

        [TestMethod]
        public void DeveConterNotificacaoIngrediente()
        {
            var mensagemIngrediente = string.Empty;

            foreach (var item in _lancheInvalido.Notificacoes)
            {
                if (item.Mensagem == LancheResource.SemIngredientes)
                    mensagemIngrediente = item.Mensagem;
            }

            Assert.AreEqual(mensagemIngrediente, LancheResource.SemIngredientes);
        }

        // Realizar mais testes

    }
}
