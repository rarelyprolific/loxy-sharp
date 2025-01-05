namespace LoxySharp.Tests;

public class TokenTests
{
    [Fact]
    public void ToStringReturnsTokenTypeWithLexemeAndLiteral()
    {
        // Arrange / Act
        var result = new Token(TokenType.IDENTIFIER, "thing", "value of thing", 0);

        // Assert
        Assert.Equal("IDENTIFIER thing value of thing", result.ToString());
    }
}
