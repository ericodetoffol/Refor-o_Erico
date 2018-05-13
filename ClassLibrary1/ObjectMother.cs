using DonaLaura.Dominio.Funcionalidade.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public static partial class ObjectMother
    {
        public static Produto GetProduto()
        {
            Produto produto = new Produto();
            produto.Nome = "Howdy";
            produto.PrecoCusto = 12;
            produto.PrecoVenda = 25;
            produto.Estoque = 10;
            produto.DataFabricacao = DateTime.Now;
            produto.DataValidade = DateTime.Now;

            return produto;
        }
    }
}
