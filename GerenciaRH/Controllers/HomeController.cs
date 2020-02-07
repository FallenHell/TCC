using GerenciaRH.Model;
using GerenciaRHBusiness;
using GerenciaRHEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CepLibrary;

namespace GerenciaRH.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string racf)
        {
            UsuarioModel modelUsuario = new UsuarioModel();
            AvaliacaoBusiness avaliacaoBusiness = new AvaliacaoBusiness();
            UsuarioBusiness business = new UsuarioBusiness();
            List<Avaliacao> listAvaliacao = new List<Avaliacao>();

            if (string.IsNullOrEmpty(racf) && Session["usuarioLogado"] != null)
            {
                modelUsuario.Usuario = (Usuario)Session["usuarioLogado"];
            }
            else
            {
                modelUsuario.Usuario = business.BuscarUsuario(racf);
            }

            if (modelUsuario.Usuario == null)
            {
                return RedirectToAction("Index", "Login");
            }
            
            modelUsuario.listUsuario = business.ListarUsuarios(modelUsuario.Usuario);

            listAvaliacao = avaliacaoBusiness.ListarAvaliacoes(modelUsuario.Usuario.IdUsuario);

            modelUsuario.QuantidadeA = listAvaliacao.Where(x => x.Nota == "A").Count();

            modelUsuario.QuantidadeB = listAvaliacao.Where(x => x.Nota == "B").Count();

            modelUsuario.QuantidadeC = listAvaliacao.Where(x => x.Nota == "C").Count();

            return View(modelUsuario);

        }

        public ActionResult PesquisarUsuario(string chave)
        {
            return PartialView();
        }
    }
}