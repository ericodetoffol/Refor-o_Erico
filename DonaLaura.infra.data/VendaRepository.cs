using DonaLaura.Dominio.Funcionalidade.Produtos;
using DonaLaura.Dominio.Funcionalidade.Vendas;
using DonaLaura.Infra;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.infra.data
{
    public class VendaRepository : IVendaRepository
    {
        #region QUERYS

        private const string SqlInsereVenda =
            @"INSERT INTO TBVENDA
                (NomeCliente, Quantidade)
            VALUES
                ({0}NomeCliente, {0}Quantidade)";

        private const string SqlEditaVenda =
            @"UPDATE TBVENDA
                SET
                    NOMECLIENTE = {0}NOMECLIENTE,
                    QUANTIDADE = {0}QUANTIDADE,
                WHERE ID = {0}ID";

        private const string SqlDeletaVenda =
           @"DELETE FROM TBVENDA
                WHERE ID = {0}ID";

        private const string SqlSelecionaTodasVenda =
        @"SELECT
                V.ID,
                V.NOMECLIENTE,
                V.QUANTIDADE,
                V.PRODUTOID,
				P.NOME AS NOMEPRODUTO

            FROM
                TBVENDA AS V
				INNER JOIN
				TBPRODUTO AS P ON P.ID = V.PRODUTOID";

        private const string SqlSelecionaVendaPorId =
            @"SELECT
                V.ID,
                V.NOMECLIENTE,
                V.QUANTIDADE,
                V.PRODUTOID,
			    P.NOME AS NOMEPRODUTO

            FROM
                TBVENDA AS V
				INNER JOIN
				TBPRODUTO AS P ON P.ID = V.PRODUTOID
            WHERE V.ID = {0}ID";

        private const string SqlSelecionaVendaPorNome =
           @"SELECT
                V.ID,
                V.NOMECLIENTE,
                V.QUANTIDADE,
                V.PRODUTOID,
				P.NOME AS NOMEPRODUTO

            FROM
                TBVENDA AS V
				INNER JOIN
				TBPRODUTO AS P ON P.ID = V.PRODUTOID
            WHERE V.NOMECLIENTE = {0}NOMECLIENTE";

        private const string SqlVerificaDependencia =
           @"SELECT
                NOMECLIENTE,
                QUANTIDADE
            FROM
                TBVENDA
            WHERE PRODUTOID = {0}ID_VENDA
                ";

        #endregion QUERYS

        public Venda Adicionar(Venda novaVenda)
        {
            novaVenda.Id = Db.Insert(SqlInsereVenda, GetParametros(novaVenda));

            return novaVenda;
        }

        public void Deletar(int id)
        {
            var parms = new Dictionary<string, object> { { "ID", id } };

            Db.Delete(SqlDeletaVenda, parms);
        }

        public Venda Editar(Venda vendaEditada)
        {
            Db.Update(SqlEditaVenda, GetParametros(vendaEditada));

            return vendaEditada;
        }

        public bool Existe(string nome)
        {
            var parms = new Dictionary<string, object> { { "NOME", nome } };

            var resultado = Db.Get(SqlSelecionaVendaPorNome, Converter, parms);

            return resultado != null;
        }

        public Venda SelecionaPorId(int id)
        {
            var parms = new Dictionary<string, object> { { "ID", id } };

            return Db.Get(SqlSelecionaVendaPorId, Converter, parms);
        }
    

        public List<Venda> SelecionaTudo()
        {
            return Db.GetAll(SqlSelecionaTodasVenda, Converter);
        }

        private static Func<IDataReader, Produto> ConverterVenda = reader =>
          new Produto
          {
              Nome = Convert.ToString(reader["NOME"])
          };

        private static Func<IDataReader, Venda> Converter = reader =>
          new Venda
          {
              Id = Convert.ToInt32(reader["ID"]),
              Produto = new Produto
              {
                  Id = Convert.ToInt32(reader["PRODUTOID"]),
              },
              NomeCliente = Convert.ToString(reader["NomeCliente"]),
              Quantidade = Convert.ToInt32(reader["Quantidade"]),
             // Lucro = Convert.ToDecimal(reader["Lucro"]),
          
          };

        private Dictionary<string, object> GetParametros(Venda venda)
        {
            return new Dictionary<string, object>
            {
                { "Id", venda.Id },
                { "ProdutoId", venda.Produto.Id },
                { "NomeCliente", venda.NomeCliente},
                { "Quantidade", venda.Quantidade },
               // { "Lucro", venda.Lucro },
            };
        }

        public bool RegistroComDependecia(int id)
        {
            var parms = new Dictionary<string, object> { { "ID_VENDA", id } };

            var resultado = Db.Get(SqlVerificaDependencia, ConverterVenda, parms);

            return resultado != null;
        }
    }
}
