using GerenciaRH.Model;
using GerenciaRH.Resources;
using GerenciaRHBusiness;
using GerenciaRHEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Util;
using Util.Enums;

namespace GerenciaRH.Controllers
{
    public class AtualizarUsuarioController : Controller
    {
        UsuarioBusiness _usrBusiness = new UsuarioBusiness();

        // GET: Desligamento
        public ActionResult AtualizarIndex(string racfUsuario)
        {
            return Json(new { redirect = "/AtualizarUsuario/Index?racfUsuario=" + racfUsuario + "" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index(string racfUsuario)
        {
            Usuario usuario = _usrBusiness.BuscarUsuario(racfUsuario);


            UsuarioModel model = new UsuarioModel();
            model.Usuario = usuario;
            var tipoCargo = (ETipoCargo)usuario.IdCargo;
            Cargo cargo = new Cargo() { TipoCargo = tipoCargo };

            model.Cargo = cargo;
            return View(model);
        }

        public ActionResult UpdateUsuario(UsuarioModel model)
        {
            Usuario usuario = new Usuario();
            var idCargo = (int)model.Cargo.TipoCargo;

            usuario = _usrBusiness.BuscarUsuario(model.Usuario.Racf);

            usuario.Email = model.Usuario.Email;
            usuario.CEP = model.Usuario.CEP;
            usuario.Endereco = model.Usuario.Endereco;
            usuario.NumeroEndereco = model.Usuario.NumeroEndereco;
            usuario.IdCargo = idCargo;

            bool sucesso = _usrBusiness.UpdateUsuario(usuario);
            if (sucesso == true)
            {
                TempData["Sucesso"] = "U";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                string mensagem = Resources.Mensagens.mensagemErroAvaliacao;
                TempData["Erro"] = mensagem;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}