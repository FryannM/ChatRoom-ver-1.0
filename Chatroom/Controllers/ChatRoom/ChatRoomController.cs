using System.Threading.Tasks;
using Chatroom.Model.Util;
using Chatroom.Service.ChatRoom;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

        [HttpPost("message")]
        public async Task<IActionResult> SendMessage([FromBody] MessageDto theMessage)
        {
            theMessage.User = "Fryann Martínez";
            var aResult = _chatRoomService.SendMessage(theMessage);
            await _chatRoomService.GetBotResponse(theMessage);
            return Ok(aResult);
        }

        [HttpGet("getMessage")]
        public async Task<IActionResult>  GetAllMessage()
        {
           var aResult = await _chatRoomService.GetAllMessage();

            var Json = JsonConvert.SerializeObject(aResult);
            return Ok(Json);
        }
    }
}
