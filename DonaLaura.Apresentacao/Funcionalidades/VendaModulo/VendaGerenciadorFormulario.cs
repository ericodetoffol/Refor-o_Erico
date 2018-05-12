using DonaLaura.Aplicacao;
using DonaLaura.Dominio.Funcionalidade.Produtos;
using DonaLaura.Dominio.Funcionalidade.Vendas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DonaLaura.Apresentacao.Funcionalidades.VendaModulo
{
    public class VendaGerenciadorFormulario : GerenciadorFormulario
    {
        private readonly VendaService _vendaService;
        private readonly ProdutoService _produtoService;
        
        private VendaControl _vendaControl;
        private IList<Produto> _produtos;
       
        public VendaGerenciadorFormulario(VendaService vendaService, ProdutoService produtoService)
        {
            _vendaService = vendaService;
            _produtoService = produtoService;
        }

        public override void Adicionar()
        {
            AtualizaComboBox();

            CadastroVendaDialog dialog = new CadastroVendaDialog(_produtos);
            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                _vendaService.Adicionar(dialog.Venda);
                ListarVendas();
            }
        }

        private void ListarVendas()
        {
            List<Venda> vendas = (List<Venda>)_vendaService.SelecionaTodas();
            _vendaControl.PopularListagemVenda(vendas);
        }

        public override void AtualizarLista()
        {
            ListarVendas();
        }

        public override UserControl CarregarListagem()
        {
            if (_vendaControl == null)
                _vendaControl = new VendaControl();

            return _vendaControl;
        }

        public override void Editar()
        {
            AtualizaComboBox();

            Venda vendaSelecionada = _vendaControl.ObtemVendaSelecionada();

            if (vendaSelecionada != null)
            {
                CadastroVendaDialog dialog = new CadastroVendaDialog(vendaSelecionada, _produtos);
                DialogResult resultado = dialog.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    _vendaService.Editar(vendaSelecionada);
                    ListarVendas();
                }

            }
            else
            {
                MessageBox.Show("Selecione uma Venda!");
            }
        }

        public override void Excluir()
        {
            Venda vendaSelecionada = _vendaControl.ObtemVendaSelecionada();

            if (vendaSelecionada != null)
            {
                DialogResult resultado = MessageBox.Show("Excluir Venda",
                    "Tem certeza que deseja excluir a Venda " + vendaSelecionada,
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (resultado == DialogResult.OK)
                {
                    _vendaService.Deletar(vendaSelecionada);

                    ListarVendas();
                }
            }
            else
            {
                MessageBox.Show("Selecione uma Venda! ");
            }
        }

        public override string ObtemTipoCadastro()
        {
            return "Cadastro de Venda";
        }

        private void AtualizaComboBox()
        {
            _produtos = _produtoService.SelecionaTodas();
        }
    }
}
