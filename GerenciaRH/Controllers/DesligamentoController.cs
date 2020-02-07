using GerenciaRH.Model;
using GerenciaRHBusiness;
using GerenciaRHEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Util;

namespace GerenciaRH.Controllers
{
    public class DesligamentoController : Controller
    {
        UsuarioBusiness _usrBusiness = new UsuarioBusiness();
        string mensagem = "";
        // GET: Desligamento
        public ActionResult DesligamentoIndex(string racfUsuario, string racfGestor)
        {
            return Json(new { redirect = "/Desligamento/Index?racfUsuario=" + racfUsuario + "&racfGestor=" + racfGestor + "" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index (string racfUsuario, string racfGestor)
        {
            try
            {
                Usuario usuarioDesligado = _usrBusiness.BuscarUsuario(racfUsuario);
                Usuario gestor = _usrBusiness.BuscarUsuario(racfGestor);

                UsuarioModel model = new UsuarioModel
                {
                    Usuario = gestor,
                    UsuarioDesligamento = usuarioDesligado
                };

                return View(model);
            }
            catch (Exception)
            {
                mensagem = Resources.Mensagens.mensagemErroBase;
                TempData["Erro"] = mensagem;
                return RedirectToAction("Home", "Index");
                
            }
            
        }

        //TODO - SALVAR NA BASE QUE USUARIO FOI DESLIGADO, RETORNANDO AVISO DE SUCESSO PRA VIEW ANTERIOR
        public ActionResult SalvarDesligamento(UsuarioModel model,UsuarioLogado usuarioLogado)
        {
            try
            {
                model.Usuario.Racf = model.UsuarioDesligamento.Racf;
                model.Usuario.IdDesligamento = usuarioLogado.usuarioLogado.IdUsuario;
                if (_usrBusiness.DeletarUsuario(model.Usuario) == false)
                {
                    mensagem = Resources.Mensagens.mensagemErroDesligamento;
                    TempData["Erro"] = mensagem;
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    Email email = new Email();

                    email.EnviarEmail(model.UsuarioDesligamento.Email, model.Usuario.Motivo, model.ComentarioDesligamento);

                    TempData["Sucesso"] = "D";
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception)
            {
                mensagem = Resources.Mensagens.mensagemErroBase;
                TempData["Erro"] = mensagem;
                return RedirectToAction("Index", "Home");
            }
        }
    }
}