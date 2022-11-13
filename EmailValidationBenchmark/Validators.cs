using System.Net.Mail;
using System.Text.RegularExpressions;

namespace EmailValidationBenchmark;

public interface IEmailValidation
{
    bool IsValid(string email);
}

public class RegexValidator : IEmailValidation
{
    public bool IsValid(string email)
    {
        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        return regex.Match(email).Success;
    }
}

public class SimpleAlgorithmValidator : IEmailValidation
{
    public bool IsValid(string email)
    {
        int userNameLength = 0;
        bool foundAtSign = false;
        int domainLength = 0;
        int domainDotCount = 0;

        foreach (var ch in email.ToCharArray())
        {
            if (ch == '@')
            {
                if (foundAtSign || userNameLength == 0)
                    return false;
                foundAtSign = true;
                continue;
            }

            if (!foundAtSign)
                userNameLength++;
            else if (ch == '.')
            {
                if (domainLength == 0)
                    return false;
                domainLength = 0;
                domainDotCount++;
            }
            else domainLength++;
        }

        if (userNameLength == 0 || domainDotCount < 1 || domainDotCount > 2 || domainLength == 0)
            return false;

        return true;
    }
}

public class NativeEmailClassValidator : IEmailValidation
{
    public bool IsValid(string email) 
        => MailAddress.TryCreate(email, out MailAddress? emailAddress);
}