using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lekser
{
    public class Lekser
    {
        public List<Token> Tokens { get; set; }
        public bool IsSuccess { get; set; } = true;
        public int Index { get; set; }
        public Token ExceptionToken { get; set; }
        public StringBuilder Number { get; set; }

        public Lekser()
        {
        }

        public void Analize(string input)
        {
            Index = 0;
            Tokens = new List<Token>();
            Number = new StringBuilder();
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
                string _ when "0123456789".Contains(argument) => BuildNumber(argument),
                _ => InitializeException(argument),
            };

        private bool BuildNumber(string argument)
        {
            if (Tokens.Count == 0)
            {
                Tokens.Add(new Token(TokenType.Digit, argument, Index++));
                return true;
            }

            var t = Tokens.Last();
            if (t.TokenType == TokenType.Digit)
                t.Argument = $"{t.Argument}{argument}";
            else
                Tokens.Add(new Token(TokenType.Digit, argument, Index++));


            return true;
        }

        private bool AddToTokens(string x, TokenType tokenType)
        {
            Tokens.Add(new Token(tokenType, x, Index++));
            return true;
        }

        private bool InitializeException(string argument)
        {
            var fail = argument;
            IsSuccess = false;
            if (string.IsNullOrEmpty(Number.ToString()))
            {
                ExceptionToken = new Token(TokenType.Unnown, argument, Index);
            }
            else
            {
                ExceptionToken = new Token(TokenType.Unnown, Number.Append(argument).ToString(), Index);
            }
            return false;
        }

    }
}
