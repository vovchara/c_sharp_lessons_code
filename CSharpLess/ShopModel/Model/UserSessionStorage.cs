using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopModel.Model
{
    public class UserSessionStorage
    {
        private static UserSessionStorage _instance;

        public static UserSessionStorage GetInstance()
        {
            if (_instance == null)
            {
                _instance = new UserSessionStorage();
            }
            return _instance;
        }
        private UserSessionStorage()
        {
        }

        private UserCredentialModel _activeUser;

        internal void SetUser(UserCredentialModel user)
        {
            if (user == null)
            {
                //log user is null
                return;
            }
            _activeUser = user;
        }

        public UserCredentialModel GetUser => _activeUser;
    }
}
