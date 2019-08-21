using System;
using System.Collections.Generic;
using SlothVm.Lex;

namespace SlothVm
{
    class Program
    {
        static void Main(string[] args)
        {
            var lexer = new Lexer();
            List<Lex.Token> tokens = lexer.Lex("puts 1");
        }
    }
}
