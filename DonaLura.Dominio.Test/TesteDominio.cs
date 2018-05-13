using System;
using DonaLaura.Dominio.Funcionalidade.Produtos;
using DonaLaura.Infra;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace DonaLura.Dominio.Test
{
    [TestFixture]
    public class TesteDominio
    {
        TestMethods formata = new TestMethods();
        Produto produto;

        [SetUp]
        public void Setup()
        {
            produto = new Produto();
        }

        [Test]
        public void Produto_Valid_ShouldBeSuccess()
        {
            produto.Id = 0;
            produto.Nome = "Chocolate";
            produto.DataFabricacao = DateTime.Now;

            produto.Valida();
        }

       

        [Test]
        public void Produto_Nome_NullOrEmpty_ShouldBeFail()
        {
            produto.Nome = "";
            produto.DataFabricacao = DateTime.Now;

            Action comparison = produto.Valida;

            comparison.Should().Throw<EmptyMessageException>();
        }

        [Test]
        public void Produto_Nome_MinChar4_ShouldBeFail()
        {
            produto.Nome = "Auy";

            produto.DataFabricacao = DateTime.Now;

            Action comparison = produto.Valida;

            comparison.Should().Throw<Exception>();
        }


        [TearDown]
        public void TearDown()
        {
            produto = null;
        }


    }
}
