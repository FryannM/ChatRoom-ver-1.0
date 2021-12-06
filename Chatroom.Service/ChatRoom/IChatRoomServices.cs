using System.Collections.Generic;
using System.Threading.Tasks;
using Chatroom.Model.Util;

namespace Chatroom.Service.ChatRoom
{
    public interface IChatRoomServices
    {
        /// <summary>
        ///  Services to send the message to RabbitMQ
        /// </summary>
        /// <param name="theMessage"></param>
        /// <returns></returns>
        bool SendMessage(MessageDto theMessage);
        /// <summary>
        /// Services that Get all the message from rabbitMQ
        /// </summary>
        /// <returns></returns>
        Task<List<RabbitMQApiResponse>> GetAllMessage();
     
        /// <summary>
        ///  Get the Bot Message
        /// </summary>
        /// <param name="theMessage">Represent the Message that we are going to Log into RabbitMQ</param>
        /// <returns></returns>
        Task<string> GetBotResponse(MessageDto theMessage);
    }
}
