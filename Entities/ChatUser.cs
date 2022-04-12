using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class ChatUser
    {
        public int ChatUserId { get; set; }
        public int UserId { get; set; }
        public int ChatId { get; set; }
        public int Level { get; set; }

        public virtual Chat Chat { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
