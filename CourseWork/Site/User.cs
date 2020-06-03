using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public abstract class User
    {
        protected long userId;
        public string userName {set; get;}
        private bool writeAccess;
        public bool active {set; get; }
        public string role { set; get; }

        protected abstract long GenerateUserID();
        public long GetUserID() => userId;

        public override string ToString()
        {
            return "User ID:" + userId + " " + "User Name:" + userName;
        }
        public bool IsWriteAccess() => writeAccess;

        public void SetAccess(bool writeAccess)
        {
            this.writeAccess = writeAccess;
        }
       
    }
}











/* public override bool Equals(Object o)
        {
            if (this == o)
                return true;
            if (!(o is User))
                return false;
            User user = (User)o;
            return Object.Equals(userName, user.userName);
        }*/
