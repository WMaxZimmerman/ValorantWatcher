using NTrospection.CLI.Core;

namespace ValorantWatcher.Console
{
   class Program
   {
       static void Main(string[] args)
       {
           new Processor().ProcessArguments(args);
       }
   }
}
