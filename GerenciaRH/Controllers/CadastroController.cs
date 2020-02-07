using Correios.Net;
using GerenciaRH.Model;
using GerenciaRHBusiness;
using GerenciaRHEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CepLibrary;
using Correios;
using Newtonsoft.Json;

namespace GerenciaRH.Controllers
{
    public class CadastroController : Controller
    {
        // GET: Cadastro
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EfetuarCadastro(UsuarioModel model, UsuarioLogado usuarioLogado)
        {

            UsuarioBusiness usuarioBusiness = new UsuarioBusiness();
            ValidaLogin validaLogin = new ValidaLogin();

            var idCargo = (int)model.Cargo.TipoCargo;

            model.Usuario.IdCargo = idCargo;
            validaLogin = usuarioBusiness.CadastrarUsuario(model.Usuario, usuarioLogado.usuarioLogado.IdUsuario);



            if (validaLogin.Sucesso == true)
            {
                TempData["Sucesso"] = "S";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Sucesso = "N";
                ViewBag.Mensagem = validaLogin.Mensagem;
                return View("Index");
            }

        }
        public JsonResult ConsultaCEP(string CEP)
        {
            CepBusiness cepBusiness = new CepBusiness();

            var dados = cepBusiness.ConsultarEndereco(CEP);

            if(dados.Logradouro == null)
            {
                return Json("error");
            }
            return Json(dados);

        }
    }
}