using GerenciaRHDao;
using GerenciaRHEntity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace GerenciaRHBusiness
{
    public class UsuarioBusiness
    {
        UsuarioDao Dao = new UsuarioDao();
        public ValidaLogin CadastrarUsuario(Usuario usuario, int usuarioLogado)
        {
            ValidaLogin validaLogin = new ValidaLogin();
            bool sucesso = true;
            try
            {
               
                if (usuario.TipoDocumento == Util.Enums.ETipoDocumento.CPF)
                {
                    if (usuario.CPFCNPJ == null || ValidarCPF(usuario.CPFCNPJ) == false)
                    {
                        validaLogin.Mensagem = "CPF inválido";
                        sucesso = false;
                        return validaLogin;

                    }

                    if (usuario.PIS == null || ValidarPis(usuario.PIS) == false )
                    {
                        validaLogin.Mensagem = "PIS Inválido";
                        sucesso = false;
                        return validaLogin;

                    }
                    if (usuario.Racf == null || usuario.Racf.Length != 4 )
                    {
                        validaLogin.Mensagem = "RACF Inválida";
                        sucesso = false;
                        return validaLogin;

                    }
                    usuario.DtAdmissao = DateTime.Now;
                    usuario.Ativo = true;
                    usuario.IdGestor = usuarioLogado;
                    usuario.IdUsuarioAlteracao = usuarioLogado;
                    if (BuscarUsuario(usuario.Racf) != null)
                    {
                        validaLogin.Mensagem = "Usuário ja Cadastrado";
                        sucesso = false;
                        return validaLogin;

                    }
                    if (AdicionarUsuario(usuario) == false)
                    {

                        validaLogin.Mensagem = "Falha ao inserir usuário";
                        sucesso = false;
                        return validaLogin;

                    }
                    validaLogin.Sucesso = sucesso;
                    return validaLogin;
                }
                else if (usuario.TipoDocumento == Util.Enums.ETipoDocumento.CNPJ)
                {
                    if (usuario.CPFCNPJ == null || ValidarCPF(usuario.CPFCNPJ) == false)
                    {
                        validaLogin.Mensagem = "Usuário ja Cadastrado";
                        sucesso = false;
                        return validaLogin;

                    }
                    if (usuario.Racf == null || usuario.Racf.Length != 4)
                    {
                        validaLogin.Mensagem = "RACF Inválida";
                        sucesso = false;
                        return validaLogin;

                    }
                    usuario.DtAdmissao = DateTime.Now;
                    usuario.Ativo = true;
                    usuario.IdGestor = usuarioLogado;
                    usuario.IdUsuarioAlteracao = usuarioLogado;
                    if (BuscarUsuario(usuario.Racf) != null)
                    {
                        validaLogin.Mensagem = "Usuário ja Cadastrado";
                        sucesso = false;
                        return validaLogin;

                    }
                    if (AdicionarUsuario(usuario) == false)
                    {
                        validaLogin.Mensagem = "Falha ao inserir usuário";
                        sucesso = false;
                        return validaLogin;

                    }
                    validaLogin.Sucesso = sucesso;
                    return validaLogin;
                }
                else
                {
                    validaLogin.Mensagem = "CPF/CNPJ não digitados";
                    sucesso = false;
                    return validaLogin;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
        public bool ValidarPis(string pis)
        {
            int[] multiplicador = new int[10] { 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;

            pis = pis.Trim();
            pis = pis.Replace("-", "").Replace(".", "").PadLeft(11, '0');
            if (pis.Trim().Length != 11)
                return false;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(pis[i].ToString()) * multiplicador[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            return pis.EndsWith(resto.ToString());
        }
        public bool ValidarCNPJ(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }
        public bool ValidarCPF(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
        public bool AdicionarUsuario(Usuario usuario)
        {
            try
            {
                string senhaCriptografada = Criptografia.GerarChaveHashMD5(usuario.Senha);
                usuario.Senha = senhaCriptografada;
                bool adicionou = Dao.AdicionarUsuario(usuario);
                return adicionou;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Usuario> ListarUsuarios(Usuario usuario)
        {
            try
            {
                List<Usuario> usuarios = Dao.ListarUsuarios(usuario);
                          
                return usuarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Usuario> ListarUsuariosSalarios(Usuario usuario)
        {
            try
            {
                List<Usuario> usuarios = Dao.ListarUsuariosSalarios(usuario);

                return usuarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeletarUsuario(Usuario usuario)
        {
            try
            {
                bool deletado = Dao.DeletarUsuario(usuario);
                return deletado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateUsuario(Usuario usuario)
        {
            try
            {
                bool efetuado = Dao.UpdateUsuario(usuario);
                return efetuado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Usuario BuscarUsuario(string racf)
        {
            try
            {
                Usuario usuario = Dao.BuscarUsuario(racf);
                return usuario;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Usuario> Relatorio()
        {
            try
            {
                List<Usuario> usuarios = Dao.Relatorio();
                return usuarios;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
