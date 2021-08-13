using System;
using NUnit.Framework;
/*
[working on] 解析傳回訊息內容
 */
namespace TestProject1
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            string context = "abc";
            var sut = new StringParser();
            
            var actual = sut.Parse(context);
            
            Assert.AreEqual(context, actual.Message);
        }
    }
}