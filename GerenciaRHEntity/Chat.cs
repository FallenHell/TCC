using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaRHEntity
{
    public class Chat
    {
        public int IdChat { get; set; }
        public int IdTipoChat { get; set; }
        public int IdMotivoChat { get; set; }
        public int UsuarioRemetente { get; set; }
        public int UsuarioDestinatario { get; set; }
        public DateTime DtEnvio { get; set; }

    }
}
