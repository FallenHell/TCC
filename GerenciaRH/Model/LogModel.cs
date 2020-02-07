using GerenciaRHEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GerenciaRH.Model
{
    public class LogModel
    {
        public Log Log{ get; set; }
        public List<Usuario> Usuarios { get; set; }
        public List<Log> Logs{ get; set; }
        public string Pesquisa { get; set; }
        public DateTime DtInicio { get; set; }
        public DateTime DtFim { get; set; }
    }
}