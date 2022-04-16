using BLL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace YuChat.Controllers
{
    [Route(("[controller]"))]
    public class ChatApiController : Controller
    {
        private readonly IChatUserService _chatUserService;
        private readonly IChatService _chatService;
        private readonly IUserService _userService;

        public ChatApiController(IChatUserService chatUserService, IChatService chatService, IUserService userService)
        {
            _chatUserService = chatUserService;
            _chatService = chatService;
            _userService = userService;
        }
        //取得列表Api
        [HttpGet]
        public IActionResult GetChatList()
        {
            var chatList = _chatUserService.GetUserChatList(int.Parse(HttpContext.Session.GetString("UserID")));
            if (!chatList.Any()) return NotFound();
            return Ok(chatList.ToList());
        }

        //新增聊天室
        [HttpPost]
        public IActionResult Add(string email)
        {
            var targetUser = _userService.Get(email);
            if (targetUser == null) return NotFound("該email不是會員");
            var user = _userService.Get(int.Parse(HttpContext.Session.GetString("UserID")));
            var chat = new Chat()
            {
                ChatName = $"{user.UserName}與{targetUser.UserName}的聊天室",
                CreateDate = DateTime.Now,
                CreateUser = user.UserId
            };

            //新增聊天室
            _chatService.Create(chat);

            var chatUser = new ChatUser()
            {
                UserId = user.UserId,
                ChatId = chat.ChatId
            };
            _chatUserService.Create(chatUser);
            chatUser = new ChatUser()
            {
                UserId = targetUser.UserId,
                ChatId = chat.ChatId
            };
            _chatUserService.Create(chatUser);

            return Ok();
        }
    }
}
