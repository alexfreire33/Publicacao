using Emergencia.Domain.Interfaces;
using Moq;

/*Ainda vai ser desenvolvido*/
namespace ApiEmergenciaXunitTeste.Aplication
{
    public class ClienteApplicationServiceTest
    {
        private readonly Mock<IClienteService> serviceClienteMock;
        public ClienteApplicationServiceTest() {
            serviceClienteMock = new Mock<IClienteService>();   
        }

        [Fact]
        public async void testeClienteGet()
        {

            serviceClienteMock.Setup(r => r.GetAsync());
        }


    }
}
