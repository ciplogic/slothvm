using System;
using System.Collections.Generic;

namespace SlothVm.Lex
{
    static class LexerExtensions
    {
        
        public static void AddRule(this List<LexerRule> rules, TokenKind kind, Func<string, int> matcher)
        {
            rules.Add(new LexerRule(){ Kind = kind, Matcher = matcher});
        }
        public static int MatchAllChars(string text, Func<char, bool> matchFirst, Func<char, bool> matchAny)
        {
            if (!matchFirst(text[0]))
                return 0;
            for (var i = 1; i < text.Length; i++)
            {
                
                if (!matchFirst(text[i]))
                    return i;
                
            }
            return text.Length;

        }
        public static int MatchAllChars(string text, Func<char, bool> matchAny)
        {
            return MatchAllChars(text, matchAny, matchAny);
        }

        public static bool MatchRange(char ch, char lo, char hi)
        {
            return (ch >= lo) && (ch <= hi);
        }
    }
}