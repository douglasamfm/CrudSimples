using Prodap.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Prodap.Repositorio
{
    public class CentroDistribuicaoRepositorio
    {

        private SqlConnection _conexao;

        private string _sql;
        private int ok;

        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexao"].ToString();
            _conexao = new SqlConnection(constr);
        }

        public bool AddCentroDistribuicao(CentroDistribuicao CdObj)
        {

            try
            { 
                Connection();

                _sql = string.Empty;
                _sql = "insert into CentroDistribuicao ( NOME,ENDERECO,TELEFONE,UF  ) VALUES  ( @NOME,@ENDERECO,@TELEFONE,@UF  )";
   
                SqlCommand command = new SqlCommand(_sql, _conexao);
 
                //Adicionando o valor das textBox nos parametros do comando
                command.Parameters.Add(new SqlParameter("@NOME", CdObj.NOME));
                command.Parameters.Add(new SqlParameter("@ENDERECO", CdObj.ENDERECO));
                command.Parameters.Add(new SqlParameter("@TELEFONE", CdObj.TELEFONE));
                command.Parameters.Add(new SqlParameter("@UF", CdObj.UF));
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

        public List<CentroDistribuicao> ListarCentroDistribuicao()
        {



                Connection();

                List<CentroDistribuicao> CDlist = new List<CentroDistribuicao>();

                _sql = string.Empty;
                _sql = "SELECT ID,NOME,ENDERECO,TELEFONE, UF  FROM CentroDistribuicao ORDER BY NOME";

                SqlCommand command = new SqlCommand(_sql, _conexao);

                _conexao.Open();
               
                SqlDataReader reader = command.ExecuteReader();

              
                while (reader.Read())
                {
                    CentroDistribuicao CD = new CentroDistribuicao()
                    {

                        ID = Convert.ToInt32(reader["ID"]),
                        NOME = reader["NOME"].ToString(),
                        ENDERECO = reader["ENDERECO"].ToString(),
                        TELEFONE = reader["TELEFONE"].ToString(),
                        UF = reader["UF"].ToString()

                    };

                    CDlist.Add(CD);
                }

            _conexao.Close();
                return CDlist;

        }

        public bool UpdCentroDistribuicao(CentroDistribuicao CdObj)
        {

            try
            {
                Connection();

                _sql = string.Empty;
                _sql = "update  CentroDistribuicao set  NOME = @NOME " +
                       " ,ENDERECO = @ENDERECO,TELEFONE = @TELEFONE,UF  = @UF" +
                       " WHERE ID = @D ";

                SqlCommand command = new SqlCommand(_sql, _conexao);

                //Adicionando o valor das textBox nos parametros do comando
                command.Parameters.Add(new SqlParameter("@NOME", CdObj.NOME));
                command.Parameters.Add(new SqlParameter("@ENDERECO", CdObj.ENDERECO));
                command.Parameters.Add(new SqlParameter("@TELEFONE", CdObj.TELEFONE));
                command.Parameters.Add(new SqlParameter("@UF", CdObj.UF));
                command.Parameters.Add(new SqlParameter("@ID", CdObj.ID));
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

        public bool DeleteCentroDistribuicao(int _ID)
        {

            try
            {
                Connection();

                _sql = string.Empty;
                _sql = "DELETE FROM   CentroDistribuicao  WHERE ID = @ID ";

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