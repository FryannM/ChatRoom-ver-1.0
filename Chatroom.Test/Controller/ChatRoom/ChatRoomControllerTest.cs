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
            var service = ChatRoomControllerFactory.GetMock();
            var controller = ChatRoomControllerFactory.GetController(service);
            var result = await controller.GetAllMessage();

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsNotType<OkResult>(okResult);
        }

        [Fact]
        public async void Test_Get_All_Message_Not_Equal ()
        {
            
            var service = ChatRoomControllerFactory.GetMockNotFound();
            var controller = ChatRoomControllerFactory.GetController(service);
            var result = await controller.GetAllMessage();

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsNotType<List<RabbitMQApiResponse>>(okResult);
            
        }
    }
}
