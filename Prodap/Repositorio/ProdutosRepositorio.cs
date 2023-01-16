using Prodap.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Prodap.Repositorio
{
    public class ProdutosRepositorio
    {

        private SqlConnection _conexao;

        private string _sql;
        private int ok;

        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexao"].ToString();
            _conexao = new SqlConnection(constr);
        }

        public bool AddProdutos(Produtos ProdObj, int ID_CENTRODISTRIBUICAO)
        {

            try
            { 
                Connection();

                _sql = string.Empty;
                _sql = "insert into Produtos (ID_PRODUTO, NOME,QUANTIDADE,ID_CENTRODISTRIBUICAO  ) VALUES  ( @ID_PRODUTO, @NOME,@QUANTIDADE,@ID_CENTRODISTRIBUICAO   )";
   
                SqlCommand command = new SqlCommand(_sql, _conexao);

                //Adicionando o valor das textBox nos parametros do comando
                command.Parameters.Add(new SqlParameter("@ID_PRODUTO", ProdObj.ID_PRODUTO));
                command.Parameters.Add(new SqlParameter("@NOME", ProdObj.NOME));
                command.Parameters.Add(new SqlParameter("@QUANTIDADE", ProdObj.QUANTIDADE));
                command.Parameters.Add(new SqlParameter("@ID_CENTRODISTRIBUICAO", ID_CENTRODISTRIBUICAO));
                //abre a conexao
                _conexao.Open();
                //executa o comando com os parametros que foram adicionados acima
                ok = command.ExecuteNonQuery();
                //fecha a conexao
                _conexao.Close();

                return ok >= 1; ;
            }
            catch
            {
                _conexao.Close();
                return false;
            }

        }

        public List<Produtos> ListarProdutos()
        {
                Connection();

                List<Produtos> ProdList = new List<Produtos>();

            _sql = string.Empty;
            _sql = " SELECT P.ID_PRODUTO,              " +
                    "       P.NOME,                    " +
                    " 	    P.QUANTIDADE,              " +
                    " 	    CD.NOME CENTRODISTRIBUICAO " +
                    "       FROM Produtos P            " +
                    "  JOIN CentroDistribuicao CD ON CD.ID = P.ID_CENTRODISTRIBUICAO " +
                    "  ORDER BY P.NOME ";

                SqlCommand command = new SqlCommand(_sql, _conexao);

                _conexao.Open();
               
                SqlDataReader reader = command.ExecuteReader();

              
                while (reader.Read())
                {
                    Produtos CD = new Produtos()
                    {

                        ID_PRODUTO = reader["ID_PRODUTO"].ToString(),
                        NOME = reader["NOME"].ToString(),
                        QUANTIDADE = Convert.ToInt32(reader["QUANTIDADE"]),
                        CENTRODISTRIBUICAO = reader["CENTRODISTRIBUICAO"].ToString()

                    };

                ProdList.Add(CD);
                }

            _conexao.Close();
                return ProdList;

        }

        public bool UpdProdutos(Produtos ProdObj, int ID_CENTRODISTRIBUICAO)
        {

            try
            {
                Connection();

                _sql = string.Empty;
                _sql = "update  Produtos set  NOME = @NOME " +
                       " ,QUANTIDADE = @QUANTIDADE,ID_CENTRODISTRIBUICAO = @ID_CENTRODISTRIBUICAO" +
                       " WHERE ID_PRODUTO = @ID_PRODUTO ";

                SqlCommand command = new SqlCommand(_sql, _conexao);

                //Adicionando o valor das textBox nos parametros do comando
                command.Parameters.Add(new SqlParameter("@NOME", ProdObj.NOME));
                command.Parameters.Add(new SqlParameter("@QUANTIDADE", ProdObj.QUANTIDADE));
                command.Parameters.Add(new SqlParameter("@ID_CENTRODISTRIBUICAO", ID_CENTRODISTRIBUICAO));
                command.Parameters.Add(new SqlParameter("@ID_PRODUTO", ProdObj.ID_PRODUTO));
         
                //abre a conexao
                _conexao.Open();
                //executa o comando com os parametros que foram adicionados acima
                ok = command.ExecuteNonQuery();
                //fecha a conexao
                _conexao.Close();

                return ok >= 1; ;
            }
            catch
            {
                _conexao.Close();
                return false;
            }

        }

        public bool DeleteProdutos(int _ID)
        {

            try
            {
                Connection();

                _sql = string.Empty;
                _sql = "DELETE FROM Produtos  WHERE ID_PRODUTO = @ID ";

                SqlCommand command = new SqlCommand(_sql, _conexao);

                //Adicionando o valor das textBox nos parametros do comando
                command.Parameters.Add(new SqlParameter("@ID",_ID));
                //abre a conexao
                _conexao.Open();
                //executa o comando com os parametros que foram adicionados acima
                ok = command.ExecuteNonQuery();
                //fecha a conexao
                _conexao.Close();

                return ok >= 1; ;
            }
            catch
            {
                _conexao.Close();
                return false;
            }

        }

    }
}