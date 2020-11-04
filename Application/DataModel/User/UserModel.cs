using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.User
{
    public class UserModel : UserAddModel
    {
        public string Id { get; set; }

        public string Salt { get; set; }
    }
    public class UserAddModel
    {
        public string UserName { get; set; }
        public string Pwd { get; set; }
    }
}
