namespace ShopModel.Model
{
    public class UserSessionStorage
    {
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
