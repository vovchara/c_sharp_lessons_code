namespace ShopModel.Model
{
    public class UserCredentialModel
    {
        public long Id { get; }
        public string Login { get; }
        public string Pass { get; }
        public string NickName { get; }

        public UserCredentialModel(long id, string login, string pass, string nickName)
        {
            Id = id;
            Login = login;
            Pass = pass;
            NickName = nickName;
        }
    }
}
