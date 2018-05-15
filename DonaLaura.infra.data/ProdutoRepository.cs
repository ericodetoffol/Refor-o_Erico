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
    public class ProdutoRepository : IProdutoRepository
    {
        #region QUERYS

        private const string SqlInsereProduto =
            @"INSERT INTO TBPRODUTO
                (Nome, PrecoVenda, PrecoCusto, Estoque, DataFabricacao, DataValidade)
            VALUES
                ({0}Nome, {0}PrecoVenda, {0}PrecoCusto, {0}Estoque, {0}DataFabricacao, {0}DataValidade)";

        private const string SqlEditaProduto =
            @"UPDATE TBPRODUTO
                SET
                    NOME = {0}NOME,
                    PRECOVENDA = {0}PRECOVENDA,
                    PRECOCUSTO = {0}PRECOCUSTO,
                    ESTOQUE = {0}ESTOQUE,
                    DATAFABRICACAO = {0}DATAFABRICACAO,
                    DATAVALIDADE = {0}DATAVALIDADE
                WHERE ID = {0}ID";

        private const string SqlDeletaProduto =
           @"DELETE FROM TBPRODUTO
                WHERE ID = {0}ID";

        private const string SqlSelecionaTodasProduto =
           @"SELECT * FROM TBPRODUTO";

        private const string SqlSelecionaProdutoPorId =
           @"SELECT
                ID,
                NOME,
                PRECOVENDA,
                PRECOCUSTO,
                ESTOQUE,
                DATAFABRICACAO,
                DATAVALIDADE
            FROM
                TBPRODUTO
            WHERE ID = {0}ID";

        private const string SqlSelecionaProdutoPorNome =
           @"SELECT
                ID,
                NOME,
                PRECOVENDA,
                PRECOCUSTO,
                ESTOQUE,
                DATAFABRICACAO,
                DATAVALIDADE
            FROM
                TBPRODUTO
            WHERE NOME = {0}NOME,
                  PRECOVENDA = {0}PRECOVENDA,
                  PRECOCUSTO = {0}PRECOCUSTO,
                  ESTOQUE = {0}ESTOQUE,
                  DATAFABRICACAO = {0}DATAFABRICACAO,
                  DATAVALIDADE = {0}DATAVALIDADE";

        private const string SqlVerificaDependencia =
           @"SELECT
                NOME,
                PRECOVENDA,
                PRECOCUSTO,
                ESTOQUE,
                DATAFABRICACAO,
                DATAVALIDADE
            FROM
                TBPRODUTO
            WHERE VENDAID = {0}ID_PRODUTO
                ";

        #endregion QUERYS


        public Produto Adicionar(Produto novoProduto)
        {
            novoProduto.Id = Db.Insert(SqlInsereProduto, GetParametros(novoProduto));

            return novoProduto;
        }

        private Dictionary<string, object> GetParametros(Produto produto)
        {
            return new Dictionary<string, object>
            {
                { "Id", produto.Id },
                { "Nome", produto.Nome },
                { "PrecoVenda", produto.PrecoVenda},
                { "PrecoCusto", produto.PrecoCusto },
                { "Estoque", produto.Estoque },
                { "DataFabricacao", produto.DataFabricacao },
                { "DataValidade", produto.DataValidade },
            };
        }

        public void Deletar(int id)
        {
            var parms = new Dictionary<string, object> { { "ID", id } };

            Db.Delete(SqlDeletaProduto, parms);
        }

        public Produto Editar(Produto produtoEditado)
        {
            Db.Update(SqlEditaProduto, GetParametros(produtoEditado));

            return produtoEditado;
        }


        public bool Existe(string nome)
        {
            var parms = new Dictionary<string, object> { { "NOME", nome } };

            var resultado = Db.Get(SqlSelecionaProdutoPorNome, Converter, parms);

            return resultado != null;
        }

        public bool RegistroComDependecia(int id)
        {
            var parms = new Dictionary<string, object> { { "ID_PRODUTO", id } };

            var resultado = Db.Get(SqlVerificaDependencia, ConverterProduto, parms);

            return resultado != null;
        }

        public Produto SelecionaPorId(int id)
        {
            var parms = new Dictionary<string, object> { { "ID", id } };

            return Db.Get(SqlSelecionaProdutoPorId, Converter, parms);
        }

        public List<Produto> SelecionaTudo()
        {
            return Db.GetAll(SqlSelecionaTodasProduto, Converter);
        }

        public Produto Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> GetAll()
        {
            throw new NotImplementedException();
        }

        private static Func<IDataReader, Produto> ConverterProduto = reader =>
            new Produto
            {
                Nome = Convert.ToString(reader["NOME"])
            };

        private static Func<IDataReader, Produto> Converter = reader =>
          new Produto
          {
              Id = Convert.ToInt32(reader["Id"]),
              Nome = Convert.ToString(reader["Nome"]),
              PrecoVenda = Convert.ToDecimal(reader["PrecoVenda"]),
              PrecoCusto = Convert.ToDecimal(reader["PrecoCusto"]),
              Estoque = Convert.ToInt32(reader["Estoque"]),
              DataFabricacao = Convert.ToDateTime(reader["DataFabricacao"]),
              DataValidade = Convert.ToDateTime(reader["DataValidade"])
          };
    }
}
