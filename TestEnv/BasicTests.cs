using EnvVariableReader;
using TestEnv.Helper;

namespace TestEnv;

public class BasicTests
{

    private EnvSimulated envSim;

    [SetUp]
    public void SetUp()
    {
        envSim = new EnvSimulated() { 
            EnvVar = new Dictionary<string, string> { { "Question", "Answer" }, {"Univers", "42"} } 
            ,
            EnvFile = []
        };
    }


    [Test]
    public void BasicGetTest()
    {
        Assert.That(new Envtest("Question", envSim).Get(), Is.EqualTo("Answer"));
    }

    [Test]
    public void ExceptionGetTest()
    { 
        Assert.That(() => new Envtest("WrongQuestion", envSim).Get(), Throws.TypeOf<EnvVariableMissingException>());
    }

    [Test]
    public void GetIntTest()
    {
        Assert.That(new Envtest("Univers", envSim).GetInt(), Is.EqualTo(42));
    }


    [Test]
    public void GetIntExceptionTest()
    {
        Assert.That(() => new Envtest("Question", envSim).GetInt(), Throws.TypeOf<EnvCannotBeParsedFoundException>());
    }

    [Test]
    public void CheckTrueTest()
    {
        Assert.That(new Envtest("Question", envSim).IsAvailable, Is.True);
    }

    [Test]
    public void CheckFalseTest()
    {
        Assert.That(new Envtest("WrongQuestion", envSim).IsAvailable, Is.False);
    }

    [Test]
    public void DisplayTest()
    {
        Assert.That(new Envtest("Question", envSim).Display(), Is.EqualTo("Question => ********"));
    }

    [Test]
    public void DisplayFullTest()
    {
        Assert.That(new Envtest("Question", envSim).Display(fullDisplay:true), Is.EqualTo("Question => Answer"));
    }

    [Test]
    public void DisplayNotFoundTest()
    {
        Assert.That(new Envtest("WrongQuestion", envSim).Display(), Is.EqualTo("WrongQuestion not found"));
    }

}



