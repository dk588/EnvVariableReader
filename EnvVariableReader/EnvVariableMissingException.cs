namespace EnvVariableReader;

public class EnvVariableMissingException : Exception
{
    internal EnvVariableMissingException(string message) :base(message) { }
}

public class EnvFileNotFoundException : Exception
{
    internal EnvFileNotFoundException(string message) : base(message) { }
}

public class EnvCannotBeParsedFoundException : Exception
{
    internal EnvCannotBeParsedFoundException(string message) : base(message) { }
}