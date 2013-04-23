using System.Web.Mvc;
using MVCSkeleton.Infrastracture.Utils.IOC;
using MVCSkeleton.Presentation.Controllers;
using MVCSkeleton.Presentation.DTOs;
using MVCSkeleton.Presentation.Models;
using TechTalk.SpecFlow;

namespace MVCSkeleton.Requirements.Context
{
    public class UserContext
    {
        private readonly static string currentcontextKey = typeof (UserContext).FullName;
        private static UserContext _instance;

        public static UserContext Current
        {
            get
            {
                if (!ScenarioContext.Current.ContainsKey(currentcontextKey))
                {
                    _instance = new UserContext();
                    ScenarioContext.Current[currentcontextKey] = _instance;
                }
                return _instance;
            }
        }

        public UserController Controller { get; set; }

        public RegisterModel RegisterModel { get; set; }

        public ActionResult RegisterResult { get; set; }

        public UserDTO LoggedUser { get; set; }

        public PasswordModel PasswordModel { get; set; }

        public ActionResult ManageResult { get; set; }

        public void InitializeController()
        {
            Controller =  IOCProvider.Instance.Get<UserController>();
        }
    }
}