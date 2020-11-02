namespace Lekser
{
    public class Token
    {
        public string TokenType { get; set; }
        public string Argument { get; set; }
        public int Index { get; set; }

        public Token(string tokenType, string argument, int index)
        {
            TokenType = tokenType;
            Argument = argument;
            Index = index;
        }

        public override string ToString() 
            => $"\nToken type: {TokenType}\nArgument: {Argument}\nIndex: {Index}\n";
    }
}
