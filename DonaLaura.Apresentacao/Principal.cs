using DonaLaura.Aplicacao;
using DonaLaura.Apresentacao.Funcionalidades;
using DonaLaura.Apresentacao.Funcionalidades.ProdutoModulo;
using DonaLaura.Apresentacao.Funcionalidades.VendaModulo;
using DonaLaura.Dominio.Funcionalidade.Produtos;
using DonaLaura.Dominio.Funcionalidade.Vendas;
using DonaLaura.infra.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DonaLaura.Apresentacao
{
    public partial class Principal : Form
    {
        private static IVendaRepository _vendaRepository = new VendaRepository();
        private static IProdutoRepository _produtoRepository = new ProdutoRepository();

        private VendaService _vendaService = new VendaService(_vendaRepository);
        private ProdutoService _produtoService = new ProdutoService(_produtoRepository);
        private GerenciadorFormulario _gerenciador;

        private VendaGerenciadorFormulario _vendaGerenciador;
        private ProdutoGerenciadorFormulario _produtoGerenciador;

        public Principal()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            _produtoGerenciador = new ProdutoGerenciadorFormulario(_produtoService);
            _vendaGerenciador = new VendaGerenciadorFormulario(_vendaService, _produtoService);
        }

        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregarCadastro(_produtoGerenciador);
            
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CarregarCadastro(_vendaGerenciador);
            
        }

        private void CarregarCadastro(GerenciadorFormulario gerenciador)
        {
            _gerenciador = gerenciador;


            labelTipoCadastro.Text = _gerenciador.ObtemTipoCadastro();

            UserControl listagem = _gerenciador.CarregarListagem();

            listagem.Dock = DockStyle.Fill;

            panelControle.Controls.Clear();

            panelControle.Controls.Add(listagem);

            _gerenciador.AtualizarLista();

            tsbSalvar.Enabled = true;
            tsbExcluir.Enabled = true;
            tsbEditar.Enabled = true;
        }

        private void tsbSalvar_Click_1(object sender, EventArgs e)
        {
            try
            {
                _gerenciador.Adicionar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");

                _gerenciador.Adicionar();
            }
        }

        private void tsbEditar_Click_1(object sender, EventArgs e)
        {
            try
            {
                _gerenciador.Editar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");

                _gerenciador.Editar();
            }
        }

        private void tsbExcluir_Click_1(object sender, EventArgs e)
        {
            _gerenciador.Excluir();
        }

        
    }
}
