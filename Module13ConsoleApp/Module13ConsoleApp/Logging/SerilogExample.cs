using System;
using Serilog;
using Serilog.Context;

namespace Module13ConsoleApp.Logging;

public class SerilogExample
{
    public static void DemonstrateSerilog()
    {
        // Створюємо папку для логів, якщо її немає
        if (!Directory.Exists("logs"))
        {
            Directory.CreateDirectory("logs");
        }

        // Configure Serilog
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("logs/serilog-.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        Console.WriteLine("=== Serilog Logging Example ===\n");

        // Different log levels
        Log.Debug("This is a DEBUG message - detailed information for debugging");
        Log.Information("This is an INFORMATION message - general information about application flow");
        Log.Warning("This is a WARNING message - potential problem or unexpected situation");
        Log.Error("This is an ERROR message - error occurred but application continues");
        Log.Fatal("This is a FATAL message - critical error that may cause application to abort");

        // Logging with exception
        try
        {
            throw new ArgumentNullException("parameter", "Example exception for logging");
        }
        catch (Exception ex)
        {
            Log.Error(ex, "An error occurred during processing");
        }

        // Structured logging (key feature of Serilog)
        string userName = "Jane Smith";
        int userId = 67890;
        Log.Information("User {UserName} (ID: {UserId}) logged in successfully", userName, userId);

        // Logging with multiple properties
        Log.Information("Processing order {OrderId} for customer {CustomerId} with total {Total:C}", 12345, 98765, 199.99m);

        // Logging object state
        var sampleObject = new { Name = "Sample", Value = 42, Active = true };
        Log.Debug("Processing object: {@Object}", sampleObject);

        Console.WriteLine("\n Serilog logging demonstration completed");
        Console.WriteLine("  Check console output and logs/serilog-*.txt files");
    }

    public static void DemonstrateSerilogStructuredLogging()
    {
        Console.WriteLine("\n=== Serilog Structured Logging ===\n");

        // Structured logging with context
        using (LogContext.PushProperty("UserId", "12345"))
        using (LogContext.PushProperty("SessionId", Guid.NewGuid()))
        {
            Log.Information("User action started");

            using (LogContext.PushProperty("Operation", "DataProcessing"))
            {
                Log.Information("Processing data");
                Log.Information("Data processed successfully");
            }

            Log.Information("User action completed");
        }

        // Performance timing
        var startTime = DateTime.UtcNow;
        System.Threading.Thread.Sleep(100); // Simulate work
        var duration = DateTime.UtcNow - startTime;
        Log.Information("Operation completed in {Duration}ms", duration.TotalMilliseconds);

        Console.WriteLine("\n Serilog structured logging demonstration completed");
    }

    public static void Cleanup()
    {
        Log.CloseAndFlush();
    }
}

