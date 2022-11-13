using EmailValidationBenchmark;

namespace EmailValidationTest;

public class ValidatorsTests
{
    [Theory, MemberData(nameof(GetEmailsList))]
    public void TestRegexValidator(string email, bool expectedResult)
    {
        var validator = new RegexValidator();
        validator.IsValid(email).Should().Be(expectedResult);
    }

    [Theory, MemberData(nameof(GetEmailsList))]
    public void TestSimpleAlgorithmValidator(string email, bool expectedResult)
    {
        var validator = new SimpleAlgorithmValidator();
        validator.IsValid(email).Should().Be(expectedResult);
    }

    [Theory, MemberData(nameof(GetEmailsList))]
    public void NativeEmailClassValidator(string email, bool expectedResult)
    {
        var validator = new NativeEmailClassValidator();
        validator.IsValid(email).Should().Be(expectedResult);
    }

    public static IEnumerable<object[]> GetEmailsList()
    {
        return new List<object[]>()
        {
            new object[]{ "user@email.com", true },
            new object[]{ "user@email.com.br", true },
            new object[]{ "a@email.com.br", true },
            new object[]{ "user.dois@email.com", true },
            new object[]{ "user@email.io", true },
            new object[]{ "user@email", false },
            new object[]{ "user.io@email", false },
            new object[]{ "user.io@email..com", false },
            new object[]{ "user.io@email.com.", false },
            new object[]{ "user.io@em@ail.com.", false }
        };
    }
}
