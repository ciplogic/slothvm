using System;

namespace SlothVm.Lex
{
    struct LexerRule
    {
        public Func<string, int> Matcher;
        public TokenKind Kind;
    }
}