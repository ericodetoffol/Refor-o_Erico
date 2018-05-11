using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Dominio.Excecoes
{
    public class DependenciaException : InvalidOperationException
    {
        public DependenciaException() : base("Esse registro possui depêndecias!")
        {
        }
    }
}
