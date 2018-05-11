using DonaLaura.Dominio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Dominio.Funcionalidade.Vendas
{
    public class Venda : Entidade
    {
        public string VendaNome {get; set;}
        public override void Valida()
        {
            throw new NotImplementedException();
        }
    }
}
