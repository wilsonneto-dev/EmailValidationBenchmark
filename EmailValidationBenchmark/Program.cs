using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using EmailValidationBenchmark;

var summary = BenchmarkRunner.Run(typeof(Program).Assembly);

[MemoryDiagnoser]
public class BenchClass
{
    readonly int totalTests = 10_000;

    [Benchmark]
    public void RegexValidator()
    {
        var validator = new RegexValidator();
        for (var i = 0; i < totalTests; i++)
            validator.IsValid("contact@newdomain.com.br");
    }

    [Benchmark]
    public void AlgorithmValidator()
    {
        var validator = new SimpleAlgorithmValidator();
        for (var i = 0; i < totalTests; i++)
            validator.IsValid("contact@newdomain.com.br");
    }

    [Benchmark]
    public void NativeEmailClassValidator()
    {
        var validator = new NativeEmailClassValidator();
        for (var i = 0; i < totalTests; i++)
            validator.IsValid("contact@newdomain.com.br");
    }
}