using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaRHEntity
{
    public class Log
    {
        public int IdLog { get; set; }
        public int IdUsuario { get; set; }
        public int IdUsuarioAlteracao { get; set; }
        public string ValorAgora { get; set; }
        public string ValorDepois { get; set; }
        public DateTime DtAlteracao { get; set; }
    }
}
