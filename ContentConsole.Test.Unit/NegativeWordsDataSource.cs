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
    class NegativeWordsDataSource
    {
        [Test]
        public void NegativeWordsDataSourceTest()
        {
            var negativeWordsDataSource = new NegativeWordsDataStore();
            Assert.IsInstanceOf(typeof(string[]), negativeWordsDataSource.GetWords());
        }
    }
}
