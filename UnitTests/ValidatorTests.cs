using EmailValidationBenchmark;

namespace EmailValidationTest;

public class ValidatorsTests
{
    [Theory,
        InlineData("user@email.com", true),
        InlineData("user@email.com.br", true),
        InlineData("a@email.com.br", true),
        InlineData("user.dois@email.com", true),
        InlineData("user@email.io", true),
        InlineData("user@email", false),
        InlineData("user.io@email", false),
        InlineData("user.io@email..com", false),
        InlineData("user.io@email.com.", false)]
    public void TestRegexValidator(string email, bool expectedResult)
    {
        var validator = new RegexValidator();
        validator.IsValid(email).Should().Be(expectedResult);
    }

    [Theory,
        InlineData("user@email.com", true),
        InlineData("user@email.com.br", true),
        InlineData("a@email.com.br", true),
        InlineData("user.dois@email.com", true),
        InlineData("user@email.io", true),
        InlineData("user@email", false),
        InlineData("user.io@email", false),
        InlineData("user.io@email..com", false),
        InlineData("user.io@email.com.", false)]
    public void TestSimpleAlgorithmValidator(string email, bool expectedResult)
    {
        var validator = new SimpleAlgorithmValidator();
        validator.IsValid(email).Should().Be(expectedResult);
    }
}