using MVCSkeleton.Domain;
using TechTalk.SpecFlow;

namespace MVCSkeleton.Requirements.Context
{
    public class UserContext
    {
        private const string key = "UserContext";
        private static UserContext _instance;
        private User currentUser;

        public static UserContext Current
        {
            get
            {
                if (!ScenarioContext.Current.ContainsKey(key))
                {
                    _instance = new UserContext();
                    ScenarioContext.Current[key] = _instance;
                }
                return _instance;
            }
        }

        public User CurrentUser
        {
            get
            {
                if (currentUser == null)
                {
                    currentUser = new User {Name = "TestUser", Password = "Pwd@123"};
                }
                return currentUser;
            }
            set { currentUser = value; }
        }

        public string NewPassword { get; set; }
    }
}