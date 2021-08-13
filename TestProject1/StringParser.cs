using System.Dynamic;

namespace TestProject1
{
    public class StringParser
    {
        public ParseResult Parse(string context)
        {
            return new ParseResult { Message = context };
        }
    }

    public class ParseResult
    {
        public string[] CCs { get; set; }
        public string Message { get; set; }
    }
}