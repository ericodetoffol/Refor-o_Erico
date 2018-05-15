using DonaLaura.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Dominio.Funcionalidade.Produtos
{
    public class MinChar4Exception : BusinessException
    {
        public MinChar4Exception() : base("Deve ter mais de 4 caracteres")
        {
        }
    }
}
