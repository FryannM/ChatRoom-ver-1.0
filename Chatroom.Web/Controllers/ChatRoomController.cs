using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Chatroom.Web.Controllers
{
    public class ChatRoomController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ChatRoom()
        {
            return View();
        }


        public JsonResult SendMessage(string message, string friend)
        {
            //RabbitMQBll obj = new RabbitMQBll();
            //IConnection con = obj.GetConnection();
            //bool flag = obj.send(con, message, friend);
            //return Json(null);
            return null;
        }

    }
}
