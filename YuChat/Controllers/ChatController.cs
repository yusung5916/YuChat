using Microsoft.AspNetCore.Mvc;

namespace YuChat.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult ChatRoom()
        {
            return View();
        }
    }
}
