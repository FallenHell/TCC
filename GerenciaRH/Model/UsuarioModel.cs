using GerenciaRHEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Util;

namespace GerenciaRH.Model
{
    public class UsuarioModel
    {
        public Avaliacao Avaliacao { get; set; }
        public Usuario Usuario { get; set; }
        public Usuario UsuarioDesligamento { get; set; }
        public Usuario UsuarioAvaliacao { get; set; }
        public List<Usuario> listUsuario { get; set; }
        public UsuarioLogado usuarioLogado { get; set; }
        public Cargo Cargo { get; set; }
        public int QuantidadeA { get; set; }
        public int QuantidadeB { get; set; }
        public int QuantidadeC { get; set; }
        public string ComentarioDesligamento { get; set; }
        public string ComentarioAvaliacaoGestor { get; set; }
        public int CargoSelecionado { get; set; }

    }
}