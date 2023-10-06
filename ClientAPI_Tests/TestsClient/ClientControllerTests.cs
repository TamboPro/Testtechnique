using ClientAPI.Controllers;
using ClientAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientAPI_Tests.TestsClient
{
    public class ClientControllerTests
    {
        private ClientContextMock _contextMock = new ClientContextMock();
        public void Dispose() => _contextMock.Dispose();

        [Fact]
        public async Task GetClients_Tous_RetourneTous()
        {
            // Arrange 
              ClientsController controller = new ClientsController(_contextMock.Context);
            // Act
              var result = await controller.GetClients();
            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<Client>>>(result);
            var returnValue = Assert.IsType<List<Client>>(actionResult.Value);
            Assert.Equal(_contextMock.Context.Clients.Count(), returnValue.Count);
        }
    }
}
