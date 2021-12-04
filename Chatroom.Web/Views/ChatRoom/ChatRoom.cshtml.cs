using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chatroom.Web.Views.ChatRoom
{
    public class ChatRoomModel : PageModel
    {
        public PageResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        [DisplayName("Message")]
        public string Message { get; set; }
    }
}
