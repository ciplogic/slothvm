using System;
using System.Collections.Generic;

namespace SlothVm.Lex
{
    public class Lexer
    {
        private static int MatchSpaces(string text)
        {
            return LexerExtensions.MatchAllChars(text, char.IsWhiteSpace);
        }

        private static readonly string[] ReservedWords =
        {
            "class", "require", "end", "def", 
            "if", "unless"
        };
        
        private static int MatchReserved(string text)
        {
            var matchIdLen = MatchIdentifier(text);
            if (matchIdLen == 0)
                return 0;
            foreach (var rw in ReservedWords)
            {
                if (text.StartsWith(rw))
                {
                    if (rw.Length == matchIdLen)
                        return matchIdLen;
                }
            }
            return 0;
        }
        
        private static int MatchIdentifier(string text)
        {
            return LexerExtensions.MatchAllChars(text, 
                c => char.IsLetter(c) || c == '_', 
                c => char.IsLetterOrDigit(c) || c == '_');
        }

        private static int MatchInteger(string text)
        {
            return LexerExtensions.MatchAllChars(text, 
                c => LexerExtensions.MatchRange(c, '0', '9'));
        }

        private LexerRule[] DefaultRules = Rules();

        private static LexerRule[] Rules()
        {
            var result = new List<LexerRule>();
            result.AddRule(TokenKind.Spaces, MatchSpaces);
            result.AddRule(TokenKind.Reserved, MatchReserved);
            result.AddRule(TokenKind.Identifier, MatchIdentifier);
            result.AddRule(TokenKind.Integer, MatchInteger);
            
            return result.ToArray();
        }
    
        
        public List<Token> Lex(string text)
        {
            
            var result = new List<Token>();
            var defaultRules = DefaultRules;
            while (text.Length>0)
            {
                var found = false;
                foreach (var lexerRule in defaultRules)
                {
                    var lenMatch = lexerRule.Matcher(text);
                    if(lenMatch==0)
                        continue;
                    found = true;
                    result.Add( new Token()
                    {
                        Kind = lexerRule.Kind,
                        Text = text.Substring(0, lenMatch)
                    });
                    text = text.Substring(lenMatch);
                    break;
                }
                if (!found)
                    throw new InvalidOperationException("Cannot lex: "+text);
                
            }
            return result;
        }
    }
}