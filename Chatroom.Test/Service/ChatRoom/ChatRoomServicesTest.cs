using System.Linq;
using Xunit;
namespace Chatroom.Test.Service.ChatRoom
{
    public class ChatRoomServicesTest
    {
        [Fact]
        public async void Test_GetAllMessage_Found()
        {
            int aTotal = 22;
            var Service = ChatRoomServicesFactory.GetService();
            var aResult =  await Service.GetAllMessage();
            Assert.Equal(aTotal, aResult.Count());
        }
    }
}
