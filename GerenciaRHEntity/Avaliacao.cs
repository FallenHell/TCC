using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Enums;

namespace GerenciaRHEntity
{
    public class Avaliacao
    {
        public int IdAvaliacao { get; set; }
        public int UsuarioAvaliado { get; set; }
        public int UsuarioAvaliador { get; set; }
        public string Nota { get; set; }
        public string UltimaAvaliacao { get; set; }
        public DateTime DtAvaliacao{ get; set; }
        public ETipoNota NotaDeveres { get; set; }
        public ETipoNota NotaClientes { get; set; }
        public ETipoNota NotaEquipe { get; set; }
        public ETipoNota NotaDesenv { get; set; }
    }

}

