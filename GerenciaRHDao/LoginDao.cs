
using System.Linq;

using Dapper;
using GerenciaRHEntity;

namespace GerenciaRHDao
{
    public class LoginDao:ConexaoBase
    {
        public Usuario SelecionarUsuario(string Racf, string Senha)
        {
            using (var conexaoDB = this.Conexao())
            {
                string sql = "select * from Usuario Where Racf = @Racf and Senha = @Senha and Ativo = 1";
                Usuario usuario = conexaoDB.Query<Usuario>(sql,new { Racf = Racf , Senha = Senha}).FirstOrDefault();
                return usuario;
            }
        }
    }
}
