using GestaoDeRH.Dominio.Util;

namespace GestaoDeRh.Tests.Helpers
{
    public class HelperTests
    {
        [Theory]
        [InlineData("colaborador@empresa.com", true)]
        [InlineData("colaborador@empresa", false)]
        [InlineData("colaborador=!3@empresa.com.br", false)]
        public void EmailValidoTestes(string email, bool valido)
        {
            Assert.Equal(valido, email.EmailEhValido());
        }
    }
}