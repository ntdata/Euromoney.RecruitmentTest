using ContentConsole.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole
{
    public class TextAnalyser
    {
        IWordsDataStore _wordsDataStore;
        public TextAnalyser(IWordsDataStore wordsDataStore)
        {
            _wordsDataStore = wordsDataStore;
        }

        public int CountWordsFromDatastore(string content)
        {
            // assuming that words in store are written in lowercase
            string[] wordsToCount = _wordsDataStore.GetWords();

            string[] source = content.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);
            var matchQuery = from word in source
                             where wordsToCount.Contains(word.ToLowerInvariant())
                             select word;
            int wordCount = matchQuery.Count();
            return wordCount;
        }
    }
}
