using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DonaLaura.infra.data;
using DonaLaura.Aplicacao;
using DonaLaura.Dominio.Funcionalidade.Vendas;

namespace DonaLaura.Apresentacao.Funcionalidades.VendaModulo
{
    public partial class VendaControl : UserControl
    {
        private VendaRepository _vendaDAO;
        private VendaService _vendaService;


        public VendaControl()
        {
            InitializeComponent();
            _vendaDAO = new VendaRepository();
            _vendaService = new VendaService(_vendaDAO);
        }

        public void PopularListagemVenda(List<Venda> vendas)
        {
            listBox1.Items.Clear();

            foreach (Venda item in vendas)
            {
                listBox1.Items.Add(item);
            }
        }

        public Venda ObtemVendaSelecionada()
        {
            return (Venda)listBox1.SelectedItem;
        }
    }
}
