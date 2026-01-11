using NLog;
using NLog.Config;
using NLog.Targets;
using NLog.Layouts;

namespace Module13ConsoleApp.Logging;

public class NLogExample
{
    private static readonly Logger logger = LogManager.GetCurrentClassLogger();

    public static void ConfigureNLog()
    {
        // Створюємо папку для логів, якщо її немає
        if (!Directory.Exists("logs"))
        {
            Directory.CreateDirectory("logs");
        }

        // Programmatic configuration
        var config = new LoggingConfiguration();

        // Console target
        var consoleTarget = new ConsoleTarget("console")
        {
            Layout = new SimpleLayout("${longdate} ${level:uppercase=true} ${logger} ${message} ${exception}")
        };
        config.AddTarget(consoleTarget);
        config.AddRule(LogLevel.Debug, LogLevel.Fatal, consoleTarget);

        // File target
        var fileTarget = new FileTarget("file")
        {
            FileName = "logs/nlog-${shortdate}.txt",
            Layout = new SimpleLayout("${longdate} ${level:uppercase=true} ${logger} ${message} ${exception}")
        };
        config.AddTarget(fileTarget);
        config.AddRule(LogLevel.Info, LogLevel.Fatal, fileTarget);

        LogManager.Configuration = config;
    }

    public static void DemonstrateNLog()
    {
        ConfigureNLog();

        Console.WriteLine("=== NLog Logging Example ===\n");

        // Different log levels
        logger.Trace("This is a TRACE message - very detailed diagnostic information");
        logger.Debug("This is a DEBUG message - detailed information for debugging");
        logger.Info("This is an INFO message - general information about application flow");
        logger.Warn("This is a WARN message - potential problem or unexpected situation");
        logger.Error("This is an ERROR message - error occurred but application continues");
        logger.Fatal("This is a FATAL message - critical error that may cause application to abort");

        // Logging with exception
        try
        {
            throw new InvalidOperationException("Example exception for NLog");
        }
        catch (Exception ex)
        {
            logger.Error(ex, "An error occurred during processing");
        }

        // Logging with parameters
        string userName = "Bob Johnson";
        int userId = 11111;
        logger.Info("User {0} (ID: {1}) logged in successfully", userName, userId);

        // Structured logging (NLog 4.5+)
        logger.Info("Processing order {OrderId} for customer {CustomerId} with total {Total}", 12345, 98765, 199.99m);

        // Logging object state
        var sampleObject = new { Name = "Sample", Value = 42 };
        logger.Debug("Processing object: {0}", sampleObject);

        Console.WriteLine("\nNLog logging demonstration completed");
        Console.WriteLine("  Check console output and logs/nlog-*.txt files");
    }

    public static void DemonstrateNLogWithContext()
    {
        Console.WriteLine("\n=== NLog Context Logging ===\n");

#pragma warning disable CS0618 // Type or member is obsolete
        // Add context properties (using legacy API for compatibility)
        // Note: In NLog 5.0+, consider using ScopeContext, but legacy API still works
        MappedDiagnosticsContext.Set("UserId", "12345");
        MappedDiagnosticsContext.Set("SessionId", Guid.NewGuid().ToString());
        MappedDiagnosticsContext.Set("RequestId", "REQ-002");

        logger.Info("Processing user request with context");

        // Nested context
        using (NestedDiagnosticsContext.Push("Operation1"))
        {
            logger.Info("Inside Operation1");
            
            using (NestedDiagnosticsContext.Push("SubOperation"))
            {
                logger.Info("Inside SubOperation");
            }
        }

        // Performance timing
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        System.Threading.Thread.Sleep(50); // Simulate work
        stopwatch.Stop();
        logger.Info("Operation completed in {0}ms", stopwatch.ElapsedMilliseconds);

        // Clear context
        MappedDiagnosticsContext.Clear();
#pragma warning restore CS0618 // Type or member is obsolete

        logger.Info("Context cleared");

        Console.WriteLine("\n✓ NLog context logging demonstration completed");
    }
}

