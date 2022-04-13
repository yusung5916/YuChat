using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace YuChat.Controllers
{
    public class ChatController : Controller
    {
        private readonly IChatUserService _chatUserService;
        public ChatController(IChatUserService chatUserService)
        {
            _chatUserService = chatUserService;
        }
        public IActionResult ChatRoom()
        {
            return View();
        }

        //取得列表Api
        public IActionResult GetChatList()
        {
            var chatList = _chatUserService.GetUserChatList(int.Parse(HttpContext.Session.GetString("UserID")));
            if (!chatList.Any()) return NotFound();
            return Ok(chatList.ToList());
        }
    }
}
