namespace LoxySharp;

/// <summary>
/// Represents a token.
/// </summary>
public class Token
{
    public TokenType Type { get; }
    public string Lexeme { get; }
    public object? Literal { get; }
    public int Line { get; }

    // TODO: Can this be extended to include the "column" and "length" of each token to enable more granular error reporting?

    public Token(TokenType type, string lexeme, object? literal, int line)
    {
        Type = type;
        Lexeme = lexeme;
        Literal = literal;
        Line = line;
    }

    public override string ToString()
    {
        return $"{Type} {Lexeme} {Literal}";
    }
}
