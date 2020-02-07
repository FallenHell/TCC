using GerenciaRHEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GerenciaRH.Model
{
    public class LoginModel
    {
        public Usuario Usuario { get; set; }
        public string Mensagem { get; set; }
        public LoginModel()
        {
            this.Usuario = new Usuario();
            this.Mensagem = "";
        }
    }
}