namespace SlothVm.Lex
{
    public enum TokenKind
    {
        Spaces,
        Identifier,
        Reserved,
        Integer
    }

    public struct Token
    {
        public TokenKind Kind;
        public string Text;
    }
}