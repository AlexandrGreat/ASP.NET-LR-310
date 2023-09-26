using System.Collections.Generic;

namespace LR4
{
    public class User
    {
        public List<UserInfo> Users { get; set; } = new();
    }

    public class UserInfo
    {
        public string Name { get; set; }
        public string Mail { get; set; }
        public string RegistrationDate { get; set; }
    }
}