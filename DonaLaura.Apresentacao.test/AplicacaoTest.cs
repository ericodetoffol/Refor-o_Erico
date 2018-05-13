using System;
using DonaLaura.Aplicacao;
using DonaLaura.Dominio.Funcionalidade.Produtos;
using FluentAssertions;
using NUnit.Framework;
using Moq;

namespace DonaLaura.Apresentacao.test
{
    [TestFixture]
    public class AplicacaoTest
    {
        private Mock<IProdutoRepository> _mockRepository;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IProdutoRepository>();
        }

        

        [Test]
        public void ProdutoService_Add_ShouldBeFail()
        {
            // Inicio Cenario

            //Modelo
            Produto modelo = new Produto()
            {
                Id = 1
            };
            //Serviço
            ProdutoService service = new ProdutoService(_mockRepository.Object);
            // Fim Cenario

            //Executa
            Action comparison = () => service.Adicionar(modelo);

            //Saída
            comparison.Should().Throw<EmptyMessageException>();
            _mockRepository.VerifyNoOtherCalls();
        }


        [Test]
        public void ProdutoService_Update_ShouldBeFail()
        {
            // Inicio Cenario

            //Modelo
            Produto modelo = new Produto()
            {
                Id = 2
            };

            //Serviço
            _mockRepository = new Mock<IProdutoRepository>();
            ProdutoService service = new ProdutoService(_mockRepository.Object);
            // Fim Cenario

            //Executa

            Action comparison = () => service.Editar(modelo);
            //Saída
            comparison.Should().Throw<EmptyMessageException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [TearDown]
        public void TearDown()
        {
            _mockRepository = null;
        }
    }
}
