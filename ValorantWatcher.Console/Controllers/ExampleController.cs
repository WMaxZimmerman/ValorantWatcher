using ValorantWatcher.ApplicationCore.Services;
using NTrospection.CLI.Attributes;
using ValorantWatcher.Shared.Models;

namespace ValorantWatcher.Console.Controllers
{
    [CliController("window", "An example of a CLI Controller")]
    public class ExampleController
    {
        [CliCommand("open", "A Hello World for a CLI Project")]
        public void OpenTwich()
        {
            ExampleService.OpenTwitch();
        }

        [CliCommand("close", "A Hello World for a CLI Project")]
        public void CloseWindow()
        {
            ExampleService.CloseBrowser();
        }

        [CliCommand("login", "A Hello World for a CLI Project")]
        public void LoginToTwitch(string username, string password)
        {
            var user = new User
            {
                Name = username,
                Password = password
            };
            ExampleService.LoginToTwitch(user);
        }

        [CliCommand("stream", "A Hello World for a CLI Project")]
        public void OpenValorantStreams()
        {
            ExampleService.OpenValorantStreams();
        }
    }
}
