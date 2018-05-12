using DonaLaura.Dominio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Dominio.Funcionalidade.Vendas
{
    public interface IVendaRepository : IRepository<Venda>
    {
        bool Existe(string enunciado);
    }
}
