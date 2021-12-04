using System.Collections.Generic;
using System.Threading.Tasks;
using Chatroom.Model.Util;

namespace Chatroom.Service.ChatRoom
{
    public interface IChatRoomServices
    {

        Task<List<RabbitMQApiResponse>> GetAllMessage();
    }
}
