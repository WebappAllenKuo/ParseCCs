using System;
using System.Linq;
using NUnit.Framework;
/*
[V] 解析傳回訊息內容
[V] 內容有 at 開頭表示要 cc 的對象, 可能是零個,一個或多個
[working on] 若連續二個 at 視為正常文字
 */
namespace TestProject1
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Parse_WhenCalled()
        {
            string context = "abc";
            var sut = new StringParser();
            
            var actual = sut.Parse(context);
            
            Assert.AreEqual(context, actual.Message);
        }
        
        [TestCase("@abc", "abc")]
        [TestCase("@abc def", "abc")]
        [TestCase("123 @abc def", "abc")]
        public void GetCCs_一個符合_傳回陣列(string context, string expected)
        {
            var sut = new StringParser();
            
            var actual = sut.GetCCs(context);
            
            Assert.AreEqual(expected, actual[0]);
        }
        
        [TestCase("")]
        [TestCase("abc")]
        public void GetCCs_沒有符合_傳回空陣列(string context)
        {
            var sut = new StringParser();
            
            var actual = sut.GetCCs(context);
            
            Assert.IsTrue(actual.Length==0);
        }
        
        [TestCase("@abc @def 123", "abc;def")]
        public void GetCCs_多個符合_傳回陣列(string context, string expected)
        {
            var sut = new StringParser();
            
            var result = sut.GetCCs(context);
            string actual = result.Aggregate((acc, next) => acc + ";" + next);
            
            Assert.AreEqual(expected, actual);
        }
        
        [TestCase("@abc @def @@123", "abc;def")]
        public void GetCCs_多個at視為普通文字_傳回陣列(string context, string expected)
        {
            var sut = new StringParser();
            
            var result = sut.GetCCs(context);
            string actual = result.Aggregate((acc, next) => acc + ";" + next);
            
            Assert.AreEqual(expected, actual);
        }
        
    }
}