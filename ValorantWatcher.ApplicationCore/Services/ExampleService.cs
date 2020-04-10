using ValorantWatcher.DAL.Repositories;

namespace ValorantWatcher.ApplicationCore.Services
{
    public class ExampleService
    {
        public static string HelloWorld()
        {
            return ExampleRepository.HelloWorld();
        }
    }
}
