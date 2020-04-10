using ValorantWatcher.DAL.Repositories;

namespace ValorantWatcher.ApplicationCore.Services
{
    public class ExampleService
    {
        public static string HelloWorld()
        {
            var repo = new ExampleRepository();
            return repo.HelloWorld();
        }
    }
}
