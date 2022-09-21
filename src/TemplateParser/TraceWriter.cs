using Microsoft.TeamFoundation.DistributedTask.Pipelines.Yaml.ObjectTemplating;

internal class TraceWriter : ITraceWriter
{
    public void Error(string format, params object[] args) => Write("FAIL", format, args, ConsoleColor.Red);

    public void Info(string format, params object[] args) => Write("INFO", format, args);

    public void Verbose(string format, params object[] args) => Write("VERB", format, args, ConsoleColor.DarkGray);

    public void Warning(string format, params object[] args) => Write("WARN", format, args, ConsoleColor.Yellow);

    public void Telemetry(TemplateTelemetry telemetry)
    {
    }

    private static void Write(string level, string format, object[] args, ConsoleColor? color = null) => ConsoleUtils.WriteLine(color, $"{level}: {format}", args);
}