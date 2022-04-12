using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class User
    {
        public User()
        {
            ChatUsers = new HashSet<ChatUser>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string BasePass { get; set; } = null!;
        public DateTime RegisterDate { get; set; }
        public DateTime? EditDate { get; set; }

        public virtual ICollection<ChatUser> ChatUsers { get; set; }
    }
}
