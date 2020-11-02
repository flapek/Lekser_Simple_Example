using System.Collections.Generic;
using System.Linq;

namespace Lekser
{
    public class Lekser
    {
        public List<Token> Tokens { get; set; }
        public bool IsSuccess { get; set; } = true;
        public int Index { get; set; }
        public Token ExceptionToken { get; set; }

        public Lekser()
        {
        }

        public void Analize(string input)
        {
            Index = 0;
            Tokens = new List<Token>();
            input.All(x => Compare(x.ToString()));
        }

        private bool Compare(string argument)
            => argument switch
            {
                "(" => AddToTokens(argument, TokenType.Bracket),
                ")" => AddToTokens(argument, TokenType.Bracket),
                "+" => AddToTokens(argument, TokenType.Operator),
                "-" => AddToTokens(argument, TokenType.Operator),
                "/" => AddToTokens(argument, TokenType.Operator),
                "*" => AddToTokens(argument, TokenType.Operator),
                " " => AddToTokens(argument, TokenType.WhiteChar),
                "0" => AddToTokens(argument, TokenType.Digit),
                string _ when "123456789".Contains(argument) => AddToTokens(argument, TokenType.Digit),
                _ => InitializeException(argument),
            };
        private bool AddToTokens(string x, string tokenType)
        {
            Tokens.Add(new Token(tokenType, x, Index++));
            return true;
        }

        private bool InitializeException(string argument)
        {
            IsSuccess = false;
            ExceptionToken = new Token("Token type is unnown", argument, Index);
            return false;
        }

    }
}
