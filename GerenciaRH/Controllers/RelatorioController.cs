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
    public class RelatorioController : Controller
    {
        // GET: Relatorio
        public ActionResult Index()
        {
            UsuarioBusiness usuarioBusiness = new UsuarioBusiness();
            
            var usuario = (Usuario)Session["usuarioLogado"];
            List<Usuario> usuarios = new List<Usuario>();
            RelatorioModel relatorioModel = new RelatorioModel();

            relatorioModel.listUsuarios = usuarioBusiness.Relatorio();

            usuarios = usuarioBusiness.ListarUsuariosSalarios(usuario);

            relatorioModel.Gerente = usuarios.Where(x => x.IdCargo == 2).ToList().Count;
            relatorioModel.GerenteRH = usuarios.Where(x => x.IdCargo == 3).ToList().Count;
            relatorioModel.FuncionarioRH = usuarios.Where(x => x.IdCargo == 4).ToList().Count;
            relatorioModel.Funcionario = usuarios.Where(x => x.IdCargo == 5).ToList().Count;
            Salarios salarios = new Salarios();

            salarios.SalarioFuncionario = (int)usuarios.Where(x => x.IdCargo == 5).Sum(x => x.Salario);
            salarios.SalarioFuncionarioRH = (int)usuarios.Where(x => x.IdCargo == 4).Sum(x => x.Salario);
            salarios.SalarioGerente = (int)usuarios.Where(x => x.IdCargo == 2).Sum(x => x.Salario);
            salarios.SalarioGerenteRH = (int)usuarios.Where(x => x.IdCargo == 3).Sum(x => x.Salario);

            relatorioModel.Salarios = salarios;
            relatorioModel.Total = relatorioModel.Salarios.SalarioFuncionario + relatorioModel.Salarios.SalarioFuncionarioRH + relatorioModel.Salarios.SalarioGerente + relatorioModel.Salarios.SalarioGerenteRH;

            return View(relatorioModel);
        }
    }
}
