using GerenciaRHEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GerenciaRH.Model
{
    public class RelatorioModel
    {
        public List<Usuario> listUsuarios { get; set; }
        public Salarios Salarios { get; set; }
        public int GerenteRH { get; set; }
        public int Gerente { get; set; }
        public int FuncionarioRH { get; set; }
        public int Funcionario { get; set; }

        public int Total { get; set; }


    }
}