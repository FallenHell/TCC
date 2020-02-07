using GerenciaRHEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GerenciaRH.Model
{
    public class UsuarioLogado
    {
        public Usuario usuarioLogado
        { get
            {
                if (HttpContext.Current.Session != null && HttpContext.Current.Session["usuarioLogado"] != null)
                {
                    return HttpContext.Current.Session["usuarioLogado"] as Usuario;
                }
                else
                {
                    return new Usuario();
                }
            }
            set
            {
                HttpContext.Current.Session["usuarioLogado"] = value;
            }
        }
    }
}