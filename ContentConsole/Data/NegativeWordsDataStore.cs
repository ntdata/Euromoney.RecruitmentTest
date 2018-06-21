using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole.Data
{
    public class NegativeWordsDataStore: IWordsDataStore
    {
        public string[] GetWords()
        {
            // assuming that words in store are written in lowercase
            return new string[] { "swine", "bad", "nasty", "horrible", "filterme" };
        }
    }
}
