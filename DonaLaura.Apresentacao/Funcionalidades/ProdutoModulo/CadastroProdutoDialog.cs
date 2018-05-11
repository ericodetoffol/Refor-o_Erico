using DonaLaura.Aplicacao;
using DonaLaura.Dominio.Funcionalidade.Produtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DonaLaura.Apresentacao.Funcionalidades.ProdutoModulo
{
    public partial class CadastroProdutoDialog : Form
    {
        private ProdutoService _servico;
        private Produto _produto;

        public CadastroProdutoDialog(ProdutoService servico)
        {
            InitializeComponent();

            _servico = servico;
        }

        public Produto Produto
        {
            get
            {
                if (_produto == null)
                    _produto = new Produto();

                _produto.Nome = txtNomeProduto.Text;
                _produto.PrecoVenda = Convert.ToDecimal(txtPrecoVenda.Text);
                _produto.PrecoCusto = Convert.ToDecimal(txtPrecoCusto.Text);
                _produto.Estoque = Convert.ToInt32(nudDisponibilidade.Text);
                _produto.DataFabricacao = Convert.ToDateTime(dtpDataFabricacao.Text);
                _produto.DataValidade = Convert.ToDateTime(dtpDataValidade.Text);

                return _produto;
            }
            set
            {
                _produto = value;
                txtNomeProduto.Text = _produto.Nome;
                txtPrecoVenda.Text = _produto.PrecoVenda.ToString();
                txtPrecoCusto.Text = _produto.PrecoCusto.ToString();
                nudDisponibilidade.Text = _produto.Estoque.ToString();
                dtpDataFabricacao.Text = _produto.DataFabricacao.ToString();
                dtpDataValidade.Text = _produto.DataValidade.ToString();
            }
        }

        private void btnSalvarProduto_Click_1(object sender, EventArgs e)
        {
            try
            {
                Produto.Valida();

            }
            catch (Exception ex)
            {
                DialogResult = DialogResult.None;
                MessageBox.Show(ex.Message, "Atenção");
            }
        }
    }
}
