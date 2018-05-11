using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DonaLaura.Aplicacao;
using DonaLaura.Dominio.Funcionalidade.Produtos;
using DonaLaura.infra.data;

namespace DonaLaura.Apresentacao.Funcionalidades.ProdutoModulo
{
    public partial class ProdutoControl : UserControl
    {
        private ProdutoRepository _produtoDAO;
        private ProdutoService _produtoService;

        public ProdutoControl()
        {
            InitializeComponent();
            _produtoDAO = new ProdutoRepository();
            _produtoService = new ProdutoService(_produtoDAO);
        }

        public void PopularListagemProduto(List<Produto> produtos)
        {
            listBox1.Items.Clear();

            foreach (Produto item in produtos)
            {
                listBox1.Items.Add(item);
            }
        }

        public Produto ObtemProdutoSelecionado()
        {
            return (Produto)listBox1.SelectedItem;
        }
    }
}
