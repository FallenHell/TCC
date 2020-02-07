using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GerenciaRHBusiness;
using GerenciaRHEntity;
using Util;
using Util.Enums;

namespace GerenciaRHTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TesteBuscarUsuario()
        {
            UsuarioBusiness usuario = new UsuarioBusiness();
            usuario.BuscarUsuario("1234");
        }
        [TestMethod]
        public void TesteListarUsuario()
        {
            Usuario usuarioe = new Usuario { IdUsuario = 1 };
            UsuarioBusiness usuario = new UsuarioBusiness();
            var x = usuario.ListarUsuarios(usuarioe);
        }

        [TestMethod]
        public void CalcularNota()
        {
            Avaliacao avaliacao = new Avaliacao();

            avaliacao.NotaClientes = ETipoNota.B;
            avaliacao.NotaDeveres = ETipoNota.B;
            avaliacao.NotaDesenv = ETipoNota.B;
            avaliacao.NotaEquipe = ETipoNota.B;

            AvaliacaoBusiness avaliacaoBusiness = new AvaliacaoBusiness();
            var teste = avaliacaoBusiness.CalcularNota(avaliacao);


        }
    }
}
