using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MVCSkeleton.IOC.Unity;
using MVCSkeleton.Infrastracture.Utils.ApplicationStartup;
using MVCSkeleton.Infrastructure.Persistance.EntityFramework.Repositories;
using MVCSkeleton.Requirements.Context;
using MVCSkeleton.Requirements.Flows;
using MVCSkeleton.Requirements.SeleniumHelpers;
using TechTalk.SpecFlow;

namespace MVCSkeleton.Requirements.Initialization
{
    [Binding]
    public static class TestInitializer
    {
        [BeforeScenario]
        public static void BeforeScenario()
        {
            CleanDatabase();
            BrowserWrapper.Instance.Start();
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            BrowserWrapper.Instance.Stop();
        }

        private static void CleanDatabase()
        {
            using (
                var connection =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                using (var command = new SqlCommand("sp_DeleteAllData", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        [BeforeScenario("alreadyLoggedIn")]
        public static void LogIn()
        {
            CreateDefaultUser();
            UserFlows.LogIn();
        }

        private static void CreateDefaultUser()
        {
            LoadIOC();
            UserRepository userRepository = new UserRepository();
            if (!userRepository.Exists(UserContext.Current.CurrentUser.Name, UserContext.Current.CurrentUser.Password))
            {
                userRepository.SaveWithCommit(UserContext.Current.CurrentUser);
            }
        }

        private static void LoadIOC()
        {
            new ApplicationStartupModuleComposite(new IApplicationStartupModule[]
                {
                    new UnityApplicationStartupModule(),
                }).Load();
        }
    }
}