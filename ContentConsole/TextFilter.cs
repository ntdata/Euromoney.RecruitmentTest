using ContentConsole.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ContentConsole
{
    public class TextFilter
    {
        IWordsDataStore _wordsDataStore;
        public TextFilter(IWordsDataStore wordsDataStore)
        {
            _wordsDataStore = wordsDataStore;
        }
        public string GetFilteredText(string content)
        {
            // assuming that words in store are written in lowercase
            string[] wordsToFilter = _wordsDataStore.GetWords();

            // initial filtering
            string cleanString = Regex.Replace(content, @"[^ .:a-zA-Z0-9\-]", "");

            // word filtering
            var re = new Regex(
                @"\b("
                + string.Join("|", wordsToFilter.Select(word =>
                string.Join(@"\s*", word.ToCharArray())))
                + @")\b", RegexOptions.IgnoreCase);
            return re.Replace(cleanString, match =>
                {
                    if (match.Length > 2)
                    {
                        return match.Value[0] + new string('*', match.Length - 2) + match.Value[match.Length - 1];
                    } else
                    {
                        return new string('*', match.Length);
                    }
                });

        }
    }
}
