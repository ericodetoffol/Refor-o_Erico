using DonaLaura.Dominio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Dominio.Funcionalidade.Produtos
{
    public class Produto : Entidade
    {
        public string Nome { get; set; }
        public decimal PrecoVenda { get; set; }
        public decimal PrecoCusto { get; set; }
        public int Estoque { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public long id { get; set; }

        public override void Valida()
        {
            if (string.IsNullOrEmpty(Nome))
                throw new InvalidOperationException("O Nome é obrigatório.");
            if (PrecoVenda == 0)
                throw new InvalidOperationException("O Preço de Venda é obrigatório.");
            if (PrecoCusto == 0)
                throw new InvalidOperationException("O Preço de Custo é obrigatório.");
            if (Estoque == 0)
                throw new InvalidOperationException("O Estoque é obrigatório.");
            if (Nome.Length < 4)
                throw new InvalidOperationException("O Nome do Produto deve ser maior que 4 caracteres!");
            if (PrecoCusto > PrecoVenda)
                throw new InvalidOperationException("O Preço de Custo deve ser menor que o Preço de Venda!");
           if (Estoque == 0)
                throw new InvalidOperationException("Oproduto não tem em estoque!");
            if (string.IsNullOrEmpty(Nome))
                throw new EmptyMessageException();
            if (Nome.Length < 4)
                throw new MinChar4Exception();
        }

        public override string ToString()
        {
            return String.Format("{0} - {1} - {2} - {3} - {4} - {5} - {6}", Id, Nome, PrecoVenda, PrecoCusto, Estoque, DataFabricacao, DataValidade);
        }
    }
}
