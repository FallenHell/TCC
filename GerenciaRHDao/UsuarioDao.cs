using GerenciaRHEntity;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaRHDao
{
    public class UsuarioDao : ConexaoBase
    {

        public bool AdicionarUsuario(Usuario usuario)
        {
            using (var conexaoBD = this.Conexao())
            {
                string sql = "insert into Usuario values(@NomeUsuario,@Racf,@CPFCNPJ,@CEP,@NumeroEndereco,@DtAdmissao,@DtDemissao,@IdCargo,@IdUsuarioAlteracao,@Senha,@Ativo,@IdGestor,@TipoDocumento,@PIS,@Motivo,@IdDesligamento,@Email,@Endereco)";
                var retorno = conexaoBD.Execute(sql,usuario);
                return retorno > 0;
            }
        }

        public List<Usuario> ListarUsuarios(Usuario usuario)
        {
            List<Usuario> retorno = new List<Usuario>();
            using (var conexaoBD = this.Conexao())
            {
                string sql = "select IdUsuario,NomeUsuario,Racf,CPFCNPJ,CEP,NumeroEndereco,DtAdmissao,DtDemissao,CA.IdCargo,IdUsuarioAlteracao,Senha,Ativo,Endereco, CA.NomeCargo"+
                    " from Usuario inner join Cargo as CA on Usuario.IdCargo = CA.IdCargo Where IdGestor = @IdGestor and Ativo = 1";
                retorno = conexaoBD.Query<Usuario>(sql,new { IdGestor = usuario.IdUsuario }).ToList();
            }
            return retorno;
        }
        public List<Usuario> ListarUsuariosSalarios(Usuario usuario)
        {
            List<Usuario> retorno = new List<Usuario>();
            using (var conexaoBD = this.Conexao())
            {
                string sql = "select IdUsuario,NomeUsuario,Racf,CPFCNPJ,CEP,NumeroEndereco,DtAdmissao,DtDemissao,CA.IdCargo,IdUsuarioAlteracao,Senha,Ativo,Endereco, CA.NomeCargo, CA.Salario " +
                    " from Usuario inner join Cargo as CA on Usuario.IdCargo = CA.IdCargo Where IdGestor = @IdGestor and Ativo = 1";
                retorno = conexaoBD.Query<Usuario>(sql, new { IdGestor = usuario.IdUsuario }).ToList();
            }
            return retorno;
        }
        public bool UpdateUsuario(Usuario usuario)
        {
            int retorno;
            using (var conexaoBD = this.Conexao())
            {
                string sql = "update Usuario set "
                    +"NomeUsuario = @NomeUsuario" 
                    +" , Racf= @Racf" 
                    +" ,CEP= @CEP" 
                    +" ,NumeroEndereco= @NumeroEndereco " 
                    +" ,DtAdmissao= @DtAdmissao" 
                    +" ,DtDemissao= @DtDemissao" 
                    +" ,IdCargo= @IdCargo" 
                    +" ,IdUsuarioAlteracao= @IdUsuarioAlteracao" 
                    +" where IdUsuario = @IdUsuario";
                retorno = conexaoBD.Execute(sql,usuario);

            }
            return retorno > 0;
        }
        public bool DeletarUsuario(Usuario usuario)
        {
            using (var conexaoBD = this.Conexao())
            {
                string sql = "update Usuario set Ativo = 0, DtDemissao = GETDATE(), Motivo = @Motivo, IdDesligamento = @IdDesligamento where Racf = @Racf";
                int retorno = conexaoBD.Execute(sql,usuario);
                return retorno > 0;
            }
        }
        public Usuario BuscarUsuario(string racf)
        {
            using (var conexaoBD = this.Conexao())
            {
                string Sql = "	select us.IdUsuario,us.NomeUsuario,us.CEP,us.CPFCNPJ,us.DtAdmissao,us.NumeroEndereco,us.IdCargo,us.Racf,us.IdGestor,us.Email,us.Endereco,ca.NomeCargo from Usuario us join Cargo ca on us.IdCargo = ca.IdCargo where us.Racf = @Racf";
                Usuario usuario = conexaoBD.Query<Usuario>(Sql, new { Racf = racf }).FirstOrDefault();
                return usuario;
            }
        }
        public List<Usuario> Relatorio()
        {
            List<Usuario> retorno = new List<Usuario>();

            using (var conexaoBD = this.Conexao())
            {
                string sql = "select us.Racf, us.NomeUsuario, av.Nota, ca.Salario from Usuario us"
                        +" join Cargo ca on us.IdCargo = ca.IdCargo"
                        + " join Avaliacao av on us.IdUsuario = av.UsuarioAvaliado"
                        + " where av.UltimaAvaliacao = 1";
                retorno = conexaoBD.Query<Usuario>(sql).ToList();

            }
            return retorno;
        }
    }
}
