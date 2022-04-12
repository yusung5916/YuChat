using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class VwuserToChatMsg
    {
        public string UserName { get; set; } = null!;
        public int ChatId { get; set; }
        public string Message { get; set; } = null!;
        public DateTime PushDate { get; set; }
    }
}
