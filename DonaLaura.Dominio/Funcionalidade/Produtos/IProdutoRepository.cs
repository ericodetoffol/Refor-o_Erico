using DonaLaura.Dominio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Dominio.Funcionalidade.Produtos
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        bool Existe(string enunciado);
    }
}
