using System.Dynamic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TestProject1
{
    public class StringParser
    {
        const string pattern = @"(^@\w[\S]*)|([^@]@\w[\S]*)"; // 開頭不是at且緊接著一段文字 or 字串中, at的前面不是 at且緊接著一段文字
        public ParseResult Parse(string context)
        {
            
            string result = Regex.Replace(context, pattern,string.Empty);
            return new ParseResult {CCs = GetCCs(context), Message = (result??string.Empty).Trim() };
            
            //return new ParseResult { Message = context };
        }

        public string[] GetCCs(string context)
        {
            // var pattern = @"(^@\w[\S]*)|([^@]@\w[\S]*)"; // 開頭不是at且緊接著一段文字 or 字串中, at的前面不是 at且緊接著一段文字
            Regex rx = new Regex(pattern);
            MatchCollection matches = rx.Matches(context);

            return matches.Cast<Match>().Select(x => x.Value.Trim().Substring(1)).ToArray();
        }
        
        
    }

    public class ParseResult
    {
        public string[] CCs { get; set; }
        public string Message { get; set; }
    }
}