namespace SlothVm.Lex
{
    public enum TokenKind
    {
        Spaces,
        Identifier,
        Reserved
    }

    public struct Token
    {
        public TokenKind Kind;
        public string Text;
    }
}