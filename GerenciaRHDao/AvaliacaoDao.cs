using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciaRHEntity;
using Dapper;

namespace GerenciaRHDao
{
    public class AvaliacaoDao:ConexaoBase
    {
        public List<Avaliacao> ListarAvaliacoes(int idGestor)
        {
            List<Avaliacao> avaliacoes;
            using (SqlConnection conexaoDB = this.Conexao())
            {
                string sql = "SELECT * FROM AVALIACAO WHERE UsuarioAvaliador = @IdGestor AND YEAR(DtAvaliacao) = YEAR(GETDATE())";
                //QUERY ANTIGA
                //string sql = "SELECT * FROM AVALIACAO WHERE UsuarioAvaliador = @IdGestor AND DtAvaliacao = DateAdd(Month, -3, GetDAte())";
                avaliacoes = conexaoDB.Query<Avaliacao>(sql,new { IdGestor = idGestor}).ToList();
            }
            return avaliacoes;
        }

        public bool InserirAvaliacao(Avaliacao avaliacao)
        {
            int qtdInserida;
            using (SqlConnection conexaoDB = this.Conexao())
            {
                string sql = "insert into Avaliacao values (@UsuarioAvaliado, @UsuarioAvaliador, @Nota, @DtAvaliacao,1)";
                qtdInserida = conexaoDB.Execute(sql, avaliacao);
                
            }
            return qtdInserida > -1 ||  qtdInserida > 0;
        }

        public bool AlterarAvaliacao(Avaliacao avaliacao)
        {
            int qtdAlterada;
            using (SqlConnection conexaoDB = this.Conexao())
            {
                string sql = "update Avaliacao set UltimaNota = 0 where UsuarioAvaliado = @UsuarioAvaliado";
                qtdAlterada = conexaoDB.Execute(sql,new { UsuarioAvaliado = avaliacao.UsuarioAvaliado});
            }
            return qtdAlterada > 0 || qtdAlterada > -1;
        }

        
    }
}
