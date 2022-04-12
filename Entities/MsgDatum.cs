using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class MsgDatum
    {
        public int ChatUserId { get; set; }
        public string Message { get; set; } = null!;
        public DateTime PushDate { get; set; }

        public virtual ChatUser ChatUser { get; set; } = null!;
    }
}
