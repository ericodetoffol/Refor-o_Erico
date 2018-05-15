using DonaLaura.Dominio.Funcionalidade.Produtos;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLura.Dominio.Test.Features
{
    [TestFixture]
    public class ProdutoDominioDonaLauraTest
    {
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
            produto.Nome = "TESTE!";
            produto.PrecoVenda = 20;
            produto.PrecoCusto = 10;
            produto.Estoque = 2;
            produto.DataFabricacao = DateTime.Now;
            produto.DataValidade = DateTime.Now.AddDays(-5);

            produto.Valida();
        }

        [Test]
        public void Produto_AddNome_ShouldBeOK()
        {
            produto.Nome = "Teste!";
            var resultado = produto.Nome;
            resultado.Should().Be("Teste!");
        }

        [TearDown]
        public void TearDown()
        {
            produto = null;
        }
    }
}
