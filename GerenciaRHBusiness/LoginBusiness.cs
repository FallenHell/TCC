using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciaRHDao;
using GerenciaRHEntity;
using Util;

namespace GerenciaRHBusiness
{
    public class LoginBusiness
    {
        public bool ValidarLogin(string Racf, string Senha)
        {
            bool validado;
            try
            {
                LoginDao dao = new LoginDao();
                if (string.IsNullOrEmpty(Racf) || string.IsNullOrEmpty(Senha))
                {
                    validado = false;
                }
                else
                {
                    string senhaCriptografada = Criptografia.GerarChaveHashMD5(Senha);
                    Usuario usuario = dao.SelecionarUsuario(Racf, senhaCriptografada);
                    validado = ValidarUsuario(usuario);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return validado;
        }

        private bool ValidarUsuario(Usuario usuario)
        {
            if (usuario == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
