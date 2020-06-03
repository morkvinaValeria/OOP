using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class RegisteredUser:User
    {
        public string email { get; }
        public string password { get; }
        
        public RegisteredUser( string userName, string password, string email)
        {
            if((userName == null)||(password ==null)|| (email ==null))
            {
                throw new ArgumentException(message: "userName or password cannot be null");
            }
            this.userName = userName;
            this.password = password;
            this.email = email;
            userId = GenerateUserID();
            SetAccess(true);
        }

        protected override long GenerateUserID()
        {
            return userName.GetHashCode() + Convert.ToInt64((DateTime.Now - DateTime.MinValue).TotalMilliseconds);
        }
    }
}