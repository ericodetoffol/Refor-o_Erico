using System;
using ClassLibrary1;
using DonaLaura.Dominio.Funcionalidade.Produtos;
using DonaLaura.infra.data;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace DonaLaura.Infraestrutura.Test
{
    [TestFixture]
    public class TestRepository
    {
        private ProdutoRepository _repository;


        [SetUp]
        public void Initialize()
        {
            _repository = new ProdutoRepository();
        }

        [Test]
        public void Produto_Save_ShouldBeOk()
        {

            Produto produto = ObjectMother.GetProduto();

            var salveProduto = _repository.Adicionar(produto);

            salveProduto.id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Post_Update_SholdBeOk()
        {
            Produto produto = ObjectMother.GetProduto();

            var updateProduto = _repository.Editar(produto);

            updateProduto.id.Should().BeGreaterThan(0);
        }


    }
}
