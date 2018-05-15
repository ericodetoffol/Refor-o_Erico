using DonaLaura.Dominio.Excecoes;
using DonaLaura.Dominio.Funcionalidade.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Aplicacao
{
    public class ProdutoService
    {
        private IProdutoRepository _produtoRepository;
        


        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public void Adicionar(Produto produto)
        {
            produto.Valida();

            _produtoRepository.Adicionar(produto);
        }

        public void Editar(Produto produto)
        {
            produto.Valida();
            _produtoRepository.Editar(produto);
        }

        public void Deletar(Produto produtoSelecionado)
        {
            _produtoRepository.Deletar(produtoSelecionado.Id);
        }

        public IList<Produto> SelecionaTodas()
        {
            return _produtoRepository.SelecionaTudo();
        }

        public Produto Add(Produto produto)
        {
            produto.Valida();

            return _produtoRepository.Adicionar(produto);
        }

        public Produto Update(Produto produto)
        {
            if (produto.Id < 1)
                throw new IdentifierUndefinedException();

            produto.Valida();

            return _produtoRepository.Editar(produto);
        }
        public Produto Get(long id)
        {
            if (id < 1)
                throw new IdentifierUndefinedException();

            return _produtoRepository.Get(id);
        }

        public IEnumerable<Produto> GetAll()
        {
            return _produtoRepository.GetAll();
        }

        public void Delete(Produto produto)
        {
            if (produto.Id < 1)
                throw new IdentifierUndefinedException();

            _produtoRepository.Deletar(produto.Id);
        }


    }
}
