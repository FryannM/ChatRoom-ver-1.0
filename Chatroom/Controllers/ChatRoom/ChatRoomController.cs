using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Chatroom.Model.Util;
using Chatroom.Service.ChatRoom;
using Chatroom.Service.Helpers.MessageConsumer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Chatroom.API.Controllers.ChatRoom
{
    [Route("api/[controller]")]
    public class ChatRoomController : Controller
    {
        private readonly IChatRoomServices _chatRoomService;

        public ChatRoomController( IChatRoomServices chatRoomServices )
        {
            _chatRoomService = chatRoomServices;
        }
       
        // POST api/values
        [HttpPost("message")]
        public void SendMessage([FromBody] string theMessage)
        {

            var connectionFactory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };

            using var connection = connectionFactory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("first-queue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);
            var message = new { User = "Fryann", Message = "Here is our first Message get this from Postman", TimeStamp = DateTime.Now };
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
            channel.BasicPublish("", "first-queue", null, body);

        }

        [HttpPost("getMessage")]
        public async  Task<IActionResult>  GetAllMessage()
        {
           var aResult = await _chatRoomService.GetAllMessage();

            return Ok(aResult);
        }
    

        private string Received ()
        {
           
            var connectionFactory = new ConnectionFactory
            {

                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };
            try
            {
                var connection = connectionFactory.CreateConnection();
                var channel = connection.CreateModel();
                var queueDeclareResponse = channel.QueueDeclare("first-queue", true, false, false, null);
                channel.BasicQos(0, 1, false);
                MessageReceiver messageReceiver = new MessageReceiver(channel);
                var theReceivedMessage = channel.BasicConsume("first-queue", false, messageReceiver);

                var consumer = new AsyncEventingBasicConsumer(channel);
                consumer.Received += async (ch, ea) =>
                {
                    var body = ea.Body.ToArray();

                    var message = JsonConvert.DeserializeObject(Encoding.UTF8.GetString(body));
                    channel.BasicAck(ea.DeliveryTag, false);
                    await Task.Yield();

                    };

                for (int i = 0; i < queueDeclareResponse.MessageCount; i++)
                {
                     

                }
                    // this consumer tag identifies the subscription
                    // when it has to be cancelled
                    // ensure we get a delivery




                }
            catch (Exception ex)
            {

            }
            return "";
        }

    }
}
