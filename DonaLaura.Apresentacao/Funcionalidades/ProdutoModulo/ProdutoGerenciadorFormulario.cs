using DonaLaura.Aplicacao;
using DonaLaura.Dominio.Funcionalidade.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DonaLaura.Apresentacao.Funcionalidades.ProdutoModulo
{
    public class ProdutoGerenciadorFormulario : GerenciadorFormulario
    {
        private readonly ProdutoService _produtoService;

        private ProdutoControl _produtoControl;
        public ProdutoGerenciadorFormulario(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        public override void Adicionar()
        {
            CadastroProdutoDialog dialog = new CadastroProdutoDialog(_produtoService);
            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                _produtoService.Adicionar(dialog.Produto);
                ListarProdutos();
            }
        }

        private void ListarProdutos()
        {
            List<Produto> produtos = (List<Produto>)_produtoService.SelecionaTodas();
            _produtoControl.PopularListagemProduto(produtos);
        }

        public override void AtualizarLista()
        {
            ListarProdutos();
        }

        public override UserControl CarregarListagem()
        {
            if (_produtoControl == null)
                _produtoControl = new ProdutoControl();

            return _produtoControl;
        }

        public override void Editar()
        {
            Produto prdutoSelecionado = _produtoControl.ObtemProdutoSelecionado();

            if (prdutoSelecionado != null)
            {
                CadastroProdutoDialog dialog = new CadastroProdutoDialog(_produtoService);
                dialog.Produto = prdutoSelecionado;
                DialogResult resultado = dialog.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    _produtoService.Editar(dialog.Produto);
                    ListarProdutos();
                }

            }
            else
            {
                MessageBox.Show("Selecione um Produto!");
            }
        }

        public override void Excluir()
        {
            Produto produtoSelecionado = _produtoControl.ObtemProdutoSelecionado();

            if (produtoSelecionado != null)
            {
                DialogResult resultado = MessageBox.Show("Excluir Produtos",
                    "Tem certeza que deseja excluir o Produto " + produtoSelecionado,
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (resultado == DialogResult.OK)
                {
                    _produtoService.Deletar(produtoSelecionado);

                    ListarProdutos();
                }
            }
            else
            {
                MessageBox.Show("Selecione um Produto!");
            }
        }

        public override string ObtemTipoCadastro()
        {
            return "Cadastro de Produtos";
        }
    }
}
