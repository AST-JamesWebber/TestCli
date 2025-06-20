using System.ComponentModel.DataAnnotations;
using TestCli.Domain.Greeter;

namespace TestCli.Domain.UnitTests.Greeter;
public class GreetTests
{
    private readonly GreeterService _sut = new GreeterService();

    [Fact]
    public void GivenFriendlyGreetingType_ThenReturnsFriendlyGreeting()
    {
        // arrange
        var request = new GreetRequest
        {
            GreetingType = GreetingType.Friendly,
            Name = "James",
        };

        // act
        var response = _sut.Greet(request);

        // assert
        Assert.Equal("Hello, James!", response);
    }

    [Fact]
    public void BadTest()
    {
        Assert.True(false, "This test is not implemented yet.");
    }

    [Fact]
    public void GivenRudeGreetingType_ThenReturnsRudeGreeting()
    {
        // arrange
        var request = new GreetRequest
        {
            GreetingType = GreetingType.Rude,
            Name = "James",
        };

        // act
        var response = _sut.Greet(request);

        // assert
        Assert.Equal("Go away, James!!", response);
    }

    [Theory]
    [InlineData(GreetingType.Friendly, null)]
    [InlineData(GreetingType.Friendly, "")]
    [InlineData(GreetingType.Friendly, " ")]
    [InlineData(GreetingType.Friendly, "          ")]
    public void GivenBadRequest_ThrowsValidationExceptionWithExpectedMessage(GreetingType greetingType, string? name)
    {
        // arrange
        var request = new GreetRequest
        {
            GreetingType = greetingType,
            Name = name,
        };

        // act
        Func<string> act = () => _sut.Greet(request);

        // assert
        Assert.Multiple(() =>
        {
            var caughtException = Assert.Throws<ValidationException>(act);
        });
    }
}
