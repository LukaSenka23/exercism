// TODO: define the 'LogLevel' enum

enum LogLevel
{
    Unknown,
    Trace,
    Debug,
    Info,
    Warning,
    Error,
    Fatal
}
static class LogLine
{
    public static LogLevel ParseLogLevel(string logLine)
    {
        int start = logLine.IndexOf('[') + 1;
        int end = logLine.IndexOf(']');
        string levelCode = logLine.Substring(start, end - start);
        
        switch (levelCode)
        {
            case "TRC": return LogLevel.Trace;
            case "DBG": return LogLevel.Debug;
            case "INF": return LogLevel.Info;
            case "WRN": return LogLevel.Warning;
            case "ERR": return LogLevel.Error;
            case "FTL": return LogLevel.Fatal;
            default:    return LogLevel.Unknown;
        }

    }

    public static string OutputForShortLog(LogLevel logLevel, string message)
    {
        int levelCode;
        
        switch (logLevel)
        {
            case LogLevel.Trace:
                levelCode = 1;
                break;
            case LogLevel.Debug:
                levelCode = 2;
                break;
            case LogLevel.Info:
                levelCode = 4;
                break;
            case LogLevel.Warning:
                levelCode = 5;
                break;
            case LogLevel.Error:
                levelCode = 6;
                break;
            case LogLevel.Fatal:
                levelCode = 42;
                break;
            default:
                levelCode = 0; 
                break;
        }
        return $"{levelCode}:{message}";
    }
}
