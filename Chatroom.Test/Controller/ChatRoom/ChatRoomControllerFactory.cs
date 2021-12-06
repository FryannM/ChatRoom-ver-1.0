using System.Threading.Tasks;
using Chatroom.API.Controllers.ChatRoom;
using Chatroom.Model.Util;
using Chatroom.Service.ChatRoom;
using Moq;

namespace Chatroom.Test.Controller.ChatRoom
{
    public class ChatRoomControllerFactory
    {
        public static ChatRoomController GetController(IMock<IChatRoomServices> mochckChatRoomService = null)
        {
            if (mochckChatRoomService == null)
                mochckChatRoomService = new Mock<IChatRoomServices>();

            return new ChatRoomController(mochckChatRoomService.Object);
        }

        internal  static Mock<IChatRoomServices> GetMock()
        {
            var service = new Mock<IChatRoomServices>();

            service.Setup(x => x.GetAllMessage())
                .Returns(Task.FromResult(new System.Collections.Generic.List<Model.Util.RabbitMQApiResponse> {
                new Model.Util.RabbitMQApiResponse{
                     payload = "User: Fryann : Message :Here we have our first Message to hit RabbitMQ TimeStamp : 2021-12-05T20:31:31.0571-05:00"
                } }));

            return service;
        }


        internal static Mock<IChatRoomServices> GetMockNotFound()
        {
            var service = new Mock<IChatRoomServices>();

            service.Setup(x => x.GetAllMessage())
               .Returns(Task.FromResult(new System.Collections.Generic.List<Model.Util.RabbitMQApiResponse> {
                new Model.Util.RabbitMQApiResponse{
                     payload = "Not Found"
                } }));

            return service;
        }
    }
}
