using System;
using Xunit;

public abstract class TestBase
{
    private readonly bool _isVerbose;

    protected TestBase()
    {
        // Check if verbose mode is enabled via command-line arguments
        var args = Environment.GetCommandLineArgs();
        _isVerbose = Array.Exists(args, arg => arg.Equals("--verbose", StringComparison.OrdinalIgnoreCase));
    }

    protected void ExecuteTest(string description, Action testLogic)
    {
        try
        {
            testLogic();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Test: {description} - Passed");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            HandleTestFailure(description, ex);
        }
    }

    protected async Task ExecuteTestAsync(string description, Func<Task> testLogic)
    {
        try
        {
            await testLogic();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Test: {description} - Passed");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            HandleTestFailure(description, ex);
        }
    }

    private void HandleTestFailure(string description, Exception ex)
    {
        // Log concise error message
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Test: {description} - Failed");
        Console.WriteLine($"Reason: {ex.Message}");
        Console.ResetColor();

        // Include stack trace if verbose mode is enabled
        if (_isVerbose)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Stack Trace:");
            Console.WriteLine(ex.StackTrace);
            Console.ResetColor();
        }

        // Fail the test explicitly using Assert
        Assert.Fail($"Test Failed: {description}");
    }
}
