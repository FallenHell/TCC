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
    public class ImpedimentoDao : ConexaoBase
    {
        public List<Impedimento> ListarImpedimentos(Impedimento impedimento)
        {
            List<Impedimento> impedimentos;
            using (SqlConnection conexaoDB = this.Conexao())
            {
                string sql = "	select TipoImpedimento from Impedimento  Where  (@IdImpedimento is null or @IdImpedimento = 0) or(IdImpedimento = @IdImpedimento) and(@TipoImpedimento is null) or(TipoImpedimento = @TipoImpedimento)";
                impedimentos = conexaoDB.Query<Impedimento>(sql,impedimento).ToList();
            }
            return impedimentos;
        }

        public bool InserirImpedimento(Impedimento impedimento)
        {
            int qtdInserida;
            using (SqlConnection conexaoDB = this.Conexao())
            {
                qtdInserida = conexaoDB.Execute("");
            }
            return qtdInserida > 0 && qtdInserida > -1;
        }

        public bool AlterarImpedimento(Impedimento impedimento)
        {
            int qtdAlterada;
            using (SqlConnection conexaoDB = this.Conexao())
            {
                string sql = "update Impedimento set TipoImpedimento = @TipoImpedimento where IdImpedimento = @IdImpedimento";
                qtdAlterada = conexaoDB.Execute(sql,impedimento);
            }
            return qtdAlterada > 0 && qtdAlterada > -1;
        }
    }
}
