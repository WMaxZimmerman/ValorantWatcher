using ValorantWatcher.ApplicationCore.Services;
using NTrospection.CLI.Attributes;
using ValorantWatcher.Shared.Models;

namespace ValorantWatcher.Console.Controllers
{
    [CliController("streams", "An example of a CLI Controller")]
    public class StreamController
    {
        [CliCommand("init", "A Hello World for a CLI Project")]
        public void OpenTwich()
        {
            ExampleService.OpenValorantStreams();
        }

        [CliCommand("list", "A Hello World for a CLI Project")]
        public void OutputAllValorantStreamUrls()
        {
            ExampleService.OutputUrls();
        }

        [CliCommand("open", "A Hello World for a CLI Project")]
        public void OpenAllValorantStreamUrls()
        {
            ExampleService.OpenAllStreams();
        }
    }
}
