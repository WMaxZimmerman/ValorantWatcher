using ValorantWatcher.DAL.Repositories;
using ValorantWatcher.Shared.Models;

namespace ValorantWatcher.ApplicationCore.Services
{
    public class ExampleService
    {
        public static void OpenTwitch()
        {
            var repo = new ExampleRepository();
            repo.Open();
        }

        public static void CloseBrowser()
        {
            var repo = new ExampleRepository();
            repo.Close();
        }

        public static void LoginToTwitch(User user)
        {
            var repo = new ExampleRepository();
            repo.LogIn(user);
        }

        public static void OpenValorantStreams()
        {
            var repo = new ExampleRepository();
            repo.NavigateToValiantStreams();
        }

        public static void OutputUrls()
        {
            var repo = new ExampleRepository();
            repo.OutputStreamUrls();
        }

        public static void OpenAllStreams()
        {
            var repo = new ExampleRepository();
            repo.OpenAllStreamUrls();
        }
    }
}
