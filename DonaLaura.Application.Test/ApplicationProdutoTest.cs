using System;
using System.Collections.Generic;
using DonaLaura.Aplicacao;
using DonaLaura.Dominio.Funcionalidade.Produtos;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;

namespace DonaLaura.Application.Test
{
    [TestFixture]
    public class ApplicationProdutoTest
    {

        private Mock<IProdutoRepository> _mockRepository;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IProdutoRepository>();
        }

        [Test]
        public void ProdutoService_Add_ShouldBeOK()
        {
            // Inicio Cenario

            //Modelo
            Produto modelo = new Produto()
            {
                Id = 1,
                Nome = "Teste!",
                PrecoVenda = 30,
                PrecoCusto = 20,
                Estoque = 5,
                DataFabricacao = DateTime.Now,
                DataValidade = DateTime.Now.AddDays(1)
            };

            _mockRepository.Setup(m => m.Adicionar(modelo)).Returns(new Produto() { Id = 1 });
            ProdutoService service = new ProdutoService(_mockRepository.Object);
            Produto resultado = service.Add(modelo);
            resultado.Should().NotBeNull();
            resultado.Id.Should().BeGreaterThan(0);
            _mockRepository.Verify(repository => repository.Adicionar(modelo));
        }

        //[Test]
        //public void PostService_Add_ShouldBeFail()
        //{
        //    // Inicio Cenario

        //    //Modelo
        //    Post modelo = new Post()
        //    {
        //        Id = 1,
        //        PostDate = DateTime.Now.AddHours(-1)
        //    };
        //    //Serviço
        //    PostService service = new PostService(_mockRepository.Object);
        //    // Fim Cenario

        //    //Executa
        //    Action comparison = () => service.Add(modelo);

        //    //Saída
        //    comparison.Should().Throw<PostMessageNullOrEmptyException>();
        //    _mockRepository.VerifyNoOtherCalls();
        //}



        [Test]
        public void ProdutoService_Update_ShouldBeOK()
        {
            Produto modelo = new Produto()
            {
                Id = 2,
                Nome = "Teste2!",
                PrecoVenda = 31,
                PrecoCusto = 22,
                Estoque = 7,
                DataFabricacao = DateTime.Now.AddHours(2),
                DataValidade = DateTime.Now.AddDays(5)
            };
            //Mock
            _mockRepository.Setup(m => m.Editar(modelo)).Returns(new Produto()
            {
                Id = 2,
                Nome = "Teste2!",
                PrecoVenda = 31,
                PrecoCusto = 42,
                Estoque = 7,
                DataFabricacao = DateTime.Now.AddHours(2),
                DataValidade = DateTime.Now.AddDays(5)            
        });

            //Serviço
            ProdutoService service = new ProdutoService(_mockRepository.Object);
            // Fim Cenario


            //Executa
            Produto resultado = service.Update(modelo);

            //Saída
            resultado.Should().NotBeNull();
            resultado.Nome.Should().Be("Teste2!");
            _mockRepository.Verify(repository => repository.Editar(modelo));

        }


        //[Test]
        //public void PostService_Update_ShouldBeFail()
        //{
        //    // Inicio Cenario

        //    //Modelo
        //    Post modelo = new Post()
        //    {
        //        Id = 2,
        //        PostDate = DateTime.Now.AddHours(-1)
        //    };

        //    //Serviço
        //    _mockRepository = new Mock<IPostRepository>();
        //    PostService service = new PostService(_mockRepository.Object);
        //    // Fim Cenario

        //    //Executa

        //    Action comparison = () => service.Update(modelo);
        //    //Saída
        //    comparison.Should().Throw<PostMessageNullOrEmptyException>();
        //    _mockRepository.VerifyNoOtherCalls();
        //}


        //[Test]
        //public void PostService_Update_Invalid_Id_ShouldBeFail()
        //{
        //    // Inicio Cenario

        //    //Modelo
        //    Post modelo = new Post()
        //    {
        //        Message = "Teste Twitter",
        //        PostDate = DateTime.Now.AddHours(-1)
        //    };

        //    //Serviço
        //    PostService service = new PostService(_mockRepository.Object);
        //    // Fim Cenario

        //    //Executa
        //    Action comparison = () => service.Update(modelo);

        //    //Saída
        //    comparison.Should().Throw<IdentifierUndefinedException>();
        //    _mockRepository.VerifyNoOtherCalls();
        //}

        [Test]
        public void ProdutoService_Get_ShouldBeOk()
        {
            _mockRepository.Setup(m => m.Get(3)).Returns(new Produto()
            {
                Id = 3,
                Nome = "Teste3!",
                PrecoVenda = 32,
                PrecoCusto = 43,
                Estoque = 8,
                DataFabricacao = DateTime.Now.AddHours(9),
                DataValidade = DateTime.Now.AddDays(12)
            });
            ProdutoService service = new ProdutoService(_mockRepository.Object);
            Produto resultado = service.Get(3);
            resultado.Should().NotBeNull();
            _mockRepository.Verify(repository => repository.Get(3));
        }

       // [Test]
        //public void PostService_Get_Invalid_Id_ShouldBeFail()
        //{
        //    // Inicio Cenario

        //    //Serviço
        //    PostService service = new PostService(_mockRepository.Object);
        //    // Fim Cenario

        //    //Executa
        //    Action comparison = () => service.Get(0);

        //    //Saída
        //    comparison.Should().Throw<IdentifierUndefinedException>();
        //    _mockRepository.VerifyNoOtherCalls();
        //}

        [Test]
        public void ProdutoService_GetAll_ShouldBeOk()
        {
            _mockRepository.Setup(m => m.GetAll()).Returns(new List<Produto>());
            ProdutoService service = new ProdutoService(_mockRepository.Object);
            IEnumerable<Produto> resultado = service.GetAll();
            resultado.Should().NotBeNull();
            _mockRepository.Verify(repository => repository.GetAll());
        }

        [Test]
        public void PostService_Delete_ShouldBeOk()
        {
            Produto modelo = new Produto()
            {
                Id = 1,
                Nome = "Teste!",
                PrecoVenda = 30,
                PrecoCusto = 40,
                Estoque = 5,
                DataFabricacao = DateTime.Now,
                DataValidade = DateTime.Now.AddDays(1)
            };
            _mockRepository.Setup(m => m.Deletar(modelo.Id));
            ProdutoService service = new ProdutoService(_mockRepository.Object);
            service.Delete(modelo);
            _mockRepository.Verify(repository => repository.Deletar(modelo.Id));
        }

        //[Test]
        //public void PostService_Delete_Invalid_Id_ShouldBeFail()
        //{
        //    // Inicio Cenario

        //    //Modelo
        //    Post modelo = new Post()
        //    {
        //        Message = "Teste Twitter",
        //        PostDate = DateTime.Now.AddHours(-1)
        //    };

        //    //Serviço
        //    PostService service = new PostService(_mockRepository.Object);
        //    // Fim Cenario

        //    //Executa
        //    Action comparison = () => service.Delete(modelo);

        //    //Saída
        //    comparison.Should().Throw<IdentifierUndefinedException>();
        //    _mockRepository.VerifyNoOtherCalls();
        //}

        [TearDown]
        public void TearDown()
        {
            _mockRepository = null;
        }
    }
}