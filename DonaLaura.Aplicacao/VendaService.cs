using DonaLaura.Dominio.Funcionalidade.Vendas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Aplicacao
{
    public class VendaService
    {
        private IVendaRepository _vendaRepository;

        public VendaService(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

        public void Adicionar(Venda venda)
        {
            venda.Valida();

            _vendaRepository.Adicionar(venda);
        }

        public void Editar(Venda venda)
        {
            venda.Valida();
            _vendaRepository.Editar(venda);
        }

        public void Deletar(Venda vendaSelecionado)
        {
            _vendaRepository.Deletar(vendaSelecionado.Id);
        }

        public IList<Venda> SelecionaTodas()
        {
            return _vendaRepository.SelecionaTudo();
        }

    }
}
