using DonaLaura.Dominio.Funcionalidade.Vendas;
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
    public class VendaDominioDonaLauraTest
    {
        Venda venda;

        [SetUp]
        public void Setup()
        {
            venda = new Venda();
        }

        [Test]
        public void Venda_Valid_ShouldBeSuccess()
        {
            venda.Id = 0;
            venda.NomeCliente = "TESTE!";
            venda.Quantidade = 10;

            venda.Valida();
        }

        [Test]
        public void Produto_AddNome_ShouldBeOK()
        {
            venda.NomeCliente = "Teste!";
            var resultado = venda.NomeCliente;
            resultado.Should().Be("Teste!");
        }

        [TearDown]
        public void TearDown()
        {
            venda = null;
        }
    }
}
