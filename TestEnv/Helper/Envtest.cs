using EnvVariableReader;
using System.Diagnostics.CodeAnalysis;

namespace TestEnv.Helper;

class Envtest : Env
{
    private readonly EnvSimulated envSimulated;

    public Envtest(string varName, EnvSimulated envSimulated) : base(varName)
    {
        this.envSimulated = envSimulated;
        SetValue();
    }

    protected override string? GetEnvironmentVariable(string _varName)
    {
        if (envSimulated == null) return null;
        if (envSimulated.EnvVar.TryGetValue(_varName, out string? result))
            return result;
        else
            return null;
    }

    protected override Boolean FileExists(string path)
    {
       return envSimulated.EnvFile.ContainsKey(path);
    }

    protected override string FileReadAllText(string path)
    {
        return envSimulated.EnvFile[path];
    }
}

class EnvSimulated
{
    public required Dictionary<string, string> EnvVar { get; set; }
    public required Dictionary<string, string> EnvFile { get; set; }

}


