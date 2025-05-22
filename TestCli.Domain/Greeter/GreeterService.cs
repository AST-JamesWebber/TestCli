using System.ComponentModel.DataAnnotations;

namespace TestCli.Domain.Greeter;
public class GreeterService
{
    public string Greet(GreetRequest request)
    {
        // validate and throw if invalid
        Validator.ValidateObject(request, new ValidationContext(request), validateAllProperties: true);

        if (request.GreetingType == GreetingType.Friendly)
        {
            return $"Hello, {request.Name}!";
        }

        return $"Go away, {request.Name}!!";
    }
}

public record GreetRequest
{
    public GreetingType GreetingType { get; init; }

    [Required]
    public string Name { get; init; } = string.Empty;
}

public enum GreetingType
{
    Friendly,
    Rude,
}
