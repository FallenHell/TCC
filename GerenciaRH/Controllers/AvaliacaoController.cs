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
    public class AvaliacaoController : Controller
    {
        UsuarioBusiness _usrBusiness = new UsuarioBusiness();
        AvaliacaoBusiness avaliacaoBusiness = new AvaliacaoBusiness();
        string mensagem = "";

        // GET: Avaliacao
        public ActionResult AvaliacaoIndex(string racfUsuario)
        {
            return Json(new { redirect = "/Avaliacao/Index?racfUsuario=" + racfUsuario +"" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index(string racfUsuario)
        {
            try
            {
                Usuario usuarioASerAvaliado = _usrBusiness.BuscarUsuario(racfUsuario);

                UsuarioModel model = new UsuarioModel
                {
                    UsuarioAvaliacao = usuarioASerAvaliado
                };
                return View(model);
            }
            catch (Exception)
            {
                mensagem = Resources.Mensagens.mensagemErroAcessoAvaliacao;
                ViewData["Erro"] = mensagem;
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpPost]
        public ActionResult EfetuarAvaliacao(UsuarioModel model, UsuarioLogado usuarioLogado,Usuario usuario)
        {
            try
            {
                model.Avaliacao.UsuarioAvaliador = usuarioLogado.usuarioLogado.IdUsuario;
                model.Avaliacao.UsuarioAvaliado = model.UsuarioAvaliacao.IdUsuario;
                bool avaliado = avaliacaoBusiness.InserirAvaliacao(model.Avaliacao);
                if (avaliado == true)
                {
                    TempData["Sucesso"] = "A";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    mensagem = Resources.Mensagens.mensagemErroAvaliacao;
                    TempData["Erro"] = mensagem;
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