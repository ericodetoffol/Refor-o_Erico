using DonaLaura.Aplicacao;
using DonaLaura.Dominio.Funcionalidade.Produtos;
using DonaLaura.Dominio.Funcionalidade.Vendas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DonaLaura.Apresentacao.Funcionalidades.VendaModulo
{
    public partial class CadastroVendaDialog : Form
    {
        private VendaService _servico;
        private Venda _venda;
        private IList<Produto> _produtos;


        public CadastroVendaDialog(ProdutoService servico)
        {
            InitializeComponent();

            AtualizaCombobox(servico.SelecionaTodas());
        }

        public Venda Venda
        {                
            get { return _venda; }
            set
            {
                _venda = value;
                cbxNomeProduto.SelectedItem = _venda.Produto.Id;
                txtNomeCliente.Text = _venda.NomeCliente;
                nudQuantidade.Text = _venda.Quantidade.ToString();
                //labelLucro.Text = _venda.Lucro.ToString();
            }
        }

        private void btnSalvarVenda_Click(object sender, System.EventArgs e)
        {
            if (_venda == null)
            {
                _venda = new Venda();
            }
            _venda.Produto = cbxNomeProduto.SelectedItem as Produto;
            _venda.NomeCliente = txtNomeCliente.Text;
            _venda.Quantidade = Convert.ToInt32(nudQuantidade.Text);
            //_venda.Lucro = Convert.ToDecimal(labelLucro.Text);

            try
            {
                _venda.Valida();

            }
            catch (Exception ex)
            {
                DialogResult = DialogResult.None;
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        private void AtualizaCombobox(IList<Produto> produtos)
        {
            cbxNomeProduto.Items.Clear();

            foreach (var item in produtos)
            {
                cbxNomeProduto.Items.Add(item);
            }
        }


    }
}
