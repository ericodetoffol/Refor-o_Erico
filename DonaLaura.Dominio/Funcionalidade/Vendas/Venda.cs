using DonaLaura.Dominio.Base;
using DonaLaura.Dominio.Funcionalidade.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Dominio.Funcionalidade.Vendas
{
    public class Venda : Entidade
    {
        public Produto Produto { get; set; }
        public string NomeCliente {get; set; }
        public int Quantidade {get; set; }
        //public decimal Lucro { get; set; }

        public override void Valida()
        {
            if (string.IsNullOrEmpty(NomeCliente))
                throw new InvalidOperationException("O Nome do cliente é obrigatório.");
            if (Quantidade < 1)
                throw new InvalidOperationException("Quantidade é obrigatório.");           
            if (NomeCliente.Length < 4)
                throw new InvalidOperationException("O Nome do Cliente deve ser maior que 4 caracteres!");         
        }

        public override string ToString()
        {
            return String.Format("{0} - {1} - {2}", Id, NomeCliente, Quantidade);
        }
    }
}
