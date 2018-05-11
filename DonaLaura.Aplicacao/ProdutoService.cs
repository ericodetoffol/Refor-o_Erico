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
    }
}
