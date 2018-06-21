using System;
using System.Linq;
using System.Reflection;
using ContentConsole.Data;
using Ninject;

namespace ContentConsole
{
    public static class Program
    {
        // It could be the Program start parameter, but it isn't specified in requirements
        static string content =
                "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

        public static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            var wordsDataStore = kernel.Get<IWordsDataStore>();

            TextAnalyser textAnalyser = new TextAnalyser(wordsDataStore);
            int badWordsCount = textAnalyser.CountWordsFromDatastore(content);

            if (args!=null && args.Count()>0 && args[0] != "0")
            {
                Console.WriteLine("Text filtering enabled. Add parameter 0 at the end of the command to disable.");
                TextFilter textFilter = new TextFilter(wordsDataStore);
                content = textFilter.GetFilteredText(content);
            } else
            {
                Console.WriteLine("Text filtering disabled.");
            }

            Console.WriteLine("Scanned the text:");
            Console.WriteLine(content);
            Console.WriteLine("Total Number of negative words: " + badWordsCount);

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }
    }

}
