using DonaLaura.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Dominio.Funcionalidade.Produtos
{
    public class EmptyMessageException : BusinessException
    {
        public EmptyMessageException() : base("Em branco")
        {
        }
    }
}
