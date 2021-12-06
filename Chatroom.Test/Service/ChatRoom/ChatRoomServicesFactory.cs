using Chatroom.Service.ChatRoom;

namespace Chatroom.Test.Service.ChatRoom
{
    public class ChatRoomServicesFactory
    {
        internal static IChatRoomServices GetService()
        {
            return new ChatRoomServices();
        }
    }
}
