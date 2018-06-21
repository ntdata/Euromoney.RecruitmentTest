using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using ContentConsole.Data;

using NUnit.Framework;

namespace ContentConsole.Test.Unit
{
    [TestFixture]
    class TextAnalyserTest
    {
        Dictionary<string, int> texts;
        string[] words = new string[] { "swine", "bad", "nasty", "horrible", "filterme" };

        [SetUp]
        public void SetUp()
        {
            //lack of time to go more abstract
            texts = new Dictionary<string, int>
            {
                { "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.", 2 },
                { "This word will be filtered despite the dot: filterme.", 1 }
            };
        }

        [Test]
        public void CountWordsFromDatastoreTest()
        {
            var mockWordStorage = new Mock<IWordsDataStore>(MockBehavior.Strict);
            mockWordStorage.Setup(s => s.GetWords())
                .Returns(words);

            TextAnalyser textAnalyser = new TextAnalyser(mockWordStorage.Object);

            foreach (KeyValuePair<string, int> item in texts)
            {
                var wordCount = textAnalyser.CountWordsFromDatastore(item.Key);
                Assert.AreEqual(item.Value, wordCount);
            }
            mockWordStorage.Verify(v => v.GetWords(), Times.Exactly(texts.Keys.Count));
        }
    }
}
