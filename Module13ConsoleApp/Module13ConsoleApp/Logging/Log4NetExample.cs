using log4net;
using log4net.Config;

namespace Module13ConsoleApp.Logging;

public class Log4NetExample
{
    private static readonly ILog log = LogManager.GetLogger(typeof(Log4NetExample));

    public static void DemonstrateLog4Net()
    {
        // Configure log4net (basic configuration)
        var logRepository = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
        BasicConfigurator.Configure(logRepository);

        // Or load from config file (uncomment if you have log4net.config)
        // XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

        Console.WriteLine("=== log4net Logging Example ===\n");

        // Different log levels
        log.Debug("This is a DEBUG message - detailed information for debugging");
        log.Info("This is an INFO message - general information about application flow");
        log.Warn("This is a WARN message - potential problem or unexpected situation");
        log.Error("This is an ERROR message - error occurred but application continues");
        log.Fatal("This is a FATAL message - critical error that may cause application to abort");

        // Logging with exception
        try
        {
            throw new InvalidOperationException("Example exception for logging");
        }
        catch (Exception ex)
        {
            log.Error("An error occurred during processing", ex);
        }

        // Logging with parameters
        string userName = "John Doe";
        int userId = 12345;
        log.InfoFormat("User {0} (ID: {1}) logged in successfully", userName, userId);

        // Logging object state
        var sampleObject = new { Name = "Sample", Value = 42 };
        log.Debug($"Processing object: {sampleObject}");

        Console.WriteLine("\n log4net logging demonstration completed");
        Console.WriteLine("  Check console output above for log messages");
    }

    public static void DemonstrateLog4NetWithContext()
    {
        Console.WriteLine("\n=== log4net Context Logging ===\n");

        // Add context information
        LogicalThreadContext.Properties["UserId"] = "12345";
        LogicalThreadContext.Properties["SessionId"] = Guid.NewGuid().ToString();
        LogicalThreadContext.Properties["RequestId"] = "REQ-001";

        log.Info("Processing user request with context");

        // Nested context
        using (LogicalThreadContext.Stacks["NDC"].Push("Operation1"))
        {
            log.Info("Inside Operation1");
            
            using (LogicalThreadContext.Stacks["NDC"].Push("SubOperation"))
            {
                log.Info("Inside SubOperation");
            }
        }

        // Clear context
        LogicalThreadContext.Properties.Clear();
        log.Info("Context cleared");

        Console.WriteLine("\n log4net context logging demonstration completed");
    }
}

