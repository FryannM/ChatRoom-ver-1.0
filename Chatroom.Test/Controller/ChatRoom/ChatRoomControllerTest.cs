using System.Collections.Generic;
using System.Threading.Tasks;
using Chatroom.Model.Util;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Chatroom.Test.Controller.ChatRoom
{
    public class ChatRoomControllerTest
    {
        [Fact]
        public async  Task Test_Get_All_Message_Ok()
        {
            int expectedValue = 1;
            var service = ChatRoomControllerFactory.GetMock();
            var controller = ChatRoomControllerFactory.GetController(service);
            var result = await controller.GetAllMessage();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<RabbitMQApiResponse>>(okResult.Value);
            Assert.Equal(expectedValue, returnValue.Count);
        }

        [Fact]
        public async void Test_Get_All_Message_Not_Equal ()
        {
            int expectedValue = 0;
            var service = ChatRoomControllerFactory.GetMockNotFound();
            var controller = ChatRoomControllerFactory.GetController(service);
            var result = await controller.GetAllMessage();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<RabbitMQApiResponse>>(okResult.Value);

            Assert.IsNotType<List<RabbitMQApiResponse>>(result);
            Assert.NotEqual(expectedValue, returnValue.Count);
        }
    }
}
