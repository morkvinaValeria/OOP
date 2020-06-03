using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class AnonymousUser:User
    {
        public AnonymousUser()
        {
            userId = GenerateUserID();
            userName = GenerateUsername();
            SetAccess(false);
            role = UserRoleType.Anonymous.ToString();
        }

        private string GenerateUsername()
        {
            StringBuilder userName = new StringBuilder("Anonymous");
            return userName.Append(userId).ToString();
        }

        protected override long GenerateUserID()
        {
            return -Convert.ToInt64((DateTime.Now - DateTime.MinValue).TotalMilliseconds);
        }
    }
}
    
