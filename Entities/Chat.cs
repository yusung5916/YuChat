using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Chat
    {
        public Chat()
        {
            ChatUsers = new HashSet<ChatUser>();
        }

        public int ChatId { get; set; }
        public string? ChatName { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUser { get; set; }

        public virtual ICollection<ChatUser> ChatUsers { get; set; }
    }
}
