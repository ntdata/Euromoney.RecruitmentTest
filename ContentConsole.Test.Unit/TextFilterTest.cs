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
    class TextFilterTest
    {
        Dictionary<string, string> texts;
        string[] words = new string[] { "swine", "bad", "nasty", "horrible", "filterme" };

        [SetUp]
        public void SetUp()
        {
            //lack of time to go more abstract
            texts = new Dictionary<string, string>
            {
                { "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.", "The weather in Manchester in winter is b*d. It rains all the time - it must be h******e for people visiting." },
                { "This word will be filtered despite the dot: filterme.", "This word will be filtered despite the dot: f******e." }
            };
        }

        [Test]
        public void CountWordsFromDatastoreTest()
        {
            var mockWordStorage = new Mock<IWordsDataStore>(MockBehavior.Strict);
            mockWordStorage.Setup(s => s.GetWords())
                .Returns(words);

            TextFilter textFilter = new TextFilter(mockWordStorage.Object);

            foreach (KeyValuePair<string, string> item in texts)
            {
                var filteredText = textFilter.GetFilteredText(item.Key);
                Assert.AreEqual(item.Value, filteredText);
            }
            mockWordStorage.Verify(v => v.GetWords(), Times.Exactly(texts.Keys.Count));
        }
    }
}
