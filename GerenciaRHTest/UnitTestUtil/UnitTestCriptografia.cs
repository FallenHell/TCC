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
    class UnitTestCriptografia
    {
        [TestMethod]
        public void TestCriptografia()
        {
            string resultado = Criptografia.GerarChaveHashMD5("123456");
            Assert.IsNotNull(resultado);
        }
    }
}
