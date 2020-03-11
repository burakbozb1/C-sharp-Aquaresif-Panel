using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaResifPanel
{
    
    
    class User
    {
        public string userName, userPass, userType, userNS;
        public int userId;

        public User(int userId, String userName, String userPass, String userType, String userNS)
        {
            this.userId = userId;
            this.userName = userName;
            this.userPass = userPass;
            this.userType = userType;
        }

        public User()
        { 
        
        }

        public void setUserId(int userId)
        {
            this.userId = userId;
        }

        public int getUserId()
        {
            return userId;
        }

        public void setUserName(string userName)
        {
            this.userName = userName;
        }
        public string getUserName()
        {
            return userName;
        }

        public void setUserPass(string userPass)
        {
            this.userPass = userPass;
        }

        public string getUserPass()
        {
            return userPass;
        }

        public void setUserType(string userType)
        {
            this.userType = userType;
        }

        public string getUserType()
        {
            return userType;
        }
        public void setUserNS(string userNS)
        {
            this.userNS = userNS;
        }
        public string getUserNS()
        {
            return userNS;
        }

        
    }
}
