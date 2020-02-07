using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace GerenciaRHTest.UnitTestUtil
{
    [TestClass]
    class UnitTestEmail
    {
        [TestMethod]
        public void TestEmail()
        {
            Email email = new Email();
            bool teste = email.EnviarEmail("teste.teste@teste.com.br", "teste", "desligamentoEfetuadoComSucesso");
            Assert.IsTrue(teste);

            bool testeFalse = email.EnviarEmail("", "teste", "desligamentoEfetuadoComSucesso");
            Assert.IsFalse(testeFalse);
            Assert.Fail();
        }
    }
}
