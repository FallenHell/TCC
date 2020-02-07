using GerenciaRH.Model;
using GerenciaRHBusiness;
using GerenciaRHEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GerenciaRH.Controllers
{
    public class LoginController : Controller
    {
        string mensagem = "";
        // GET: Login
        public ActionResult Index()
        {
            LoginModel model = new LoginModel();
            return View(model);
        }
        public ActionResult EfetuarLogin(LoginModel model)
        {
            try
            {
                LoginBusiness Loginbusiness = new LoginBusiness();
                bool loginEfetuado = Loginbusiness.ValidarLogin(model.Usuario.Racf, model.Usuario.Senha);
                if (loginEfetuado)
                {
                    UsuarioBusiness usuarioBusiness = new UsuarioBusiness();
                    Usuario userLogado = usuarioBusiness.BuscarUsuario(model.Usuario.Racf);

                    Session["usuarioLogado"] = userLogado;

                    return RedirectToAction("Index", "Home", new { racf = model.Usuario.Racf });
                }
                else
                {
                    mensagem = Resources.Mensagens.mensagemErroLogin;
                    TempData["Erro"] = mensagem;
                    return View("Index");
                }
            }
            catch (Exception)
            {
                mensagem = Resources.Mensagens.mensagemErroBase;
                TempData["Erro"] = mensagem;
                return View("Index");
            }
            
        }
    }
}