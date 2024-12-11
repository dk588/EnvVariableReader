
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;

namespace EnvVariableReader;

public class Env
{

    protected readonly string varName;
    private string? varValue;
    
    public Env(string varName) {
        this.varName = varName;
        SetValue();
            }

    protected void SetValue() {
        varValue = GetEnvironmentVariable(varName);
        if (varValue == null)
        {
            var CheckFile= GetEnvironmentVariable(varName + "_FILE");
            if (CheckFile != null)
                if (FileExists(CheckFile))
                {
                    varValue = FileReadAllText(CheckFile).Trim();  
                }
                else
                {
                    throw new EnvFileNotFoundException($"{varName} cannot find file {CheckFile}");
                }
        }
    }

    public string Get()
    {
        if (varValue == null)
            throw new EnvVariableMissingException($"{varName} is not set");

        return varValue;
    }

    public int GetInt()
    {
        
        if (int.TryParse(Get(), out int result))
            return result;
        else
            throw new EnvCannotBeParsedFoundException($"{varName} value cannot be parsed in int: {Get()}");

    }

    public bool IsAvailable => varValue != null;

    public string Display(bool fullDisplay = false)
    {
        if (IsAvailable)
            if (fullDisplay)
                return $"{varName} => {varValue}";
            else
                return $"{varName} => ********";
        else
            return $"{varName} not found";
    }
    

    [ExcludeFromCodeCoverage]
    protected  virtual String? GetEnvironmentVariable(string _varName)
    {
        return Environment.GetEnvironmentVariable(_varName);  
    }

    [ExcludeFromCodeCoverage]
    protected virtual Boolean FileExists(string path)
    {
      
            return File.Exists(path);
    } 
    [ExcludeFromCodeCoverage]
    protected virtual string FileReadAllText(string path)
    {
      
            return File.ReadAllText(path);
    }
}
