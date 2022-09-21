using Microsoft.TeamFoundation.DistributedTask.Pipelines.Yaml.ObjectTemplating;
using System.Text;

internal class YamlTraceWriter : ITraceWriter
{
    private readonly StringBuilder _sb = new();

    public void Info(string format, params object[] args) => _sb.AppendFormat(format, args);

    public override string ToString() => _sb.ToString();

    public void Error(string format, params object[] args) => throw new NotSupportedException();

    public void Telemetry(TemplateTelemetry telemetry) => throw new NotSupportedException();

    public void Verbose(string format, params object[] args) => throw new NotSupportedException();

    public void Warning(string format, params object[] args) => throw new NotSupportedException();
}
