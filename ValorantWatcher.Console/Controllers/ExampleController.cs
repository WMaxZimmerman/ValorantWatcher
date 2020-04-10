using ValorantWatcher.ApplicationCore.Services;
using NTrospection.CLI.Attributes;

namespace ValorantWatcher.Console.Controllers
{
    [CliController("example", "An example of a CLI Controller")]
    public class ExampleController
    {
        [CliCommand("hello", "A Hello World for a CLI Project")]
        public void HelloWorld()
        {
            System.Console.WriteLine(ExampleService.HelloWorld());
        }
    }
}
