
using TestEnv.Helper;

namespace TestEnv;

internal class FileTests
{
    private EnvSimulated envSim;

    [SetUp]
    public void SetUp()
    {
        envSim = new EnvSimulated() { 
            EnvVar = new Dictionary<string, string> { { "Question_FILE", "/run/secrets/question" },{ "Univers_FILE", "/run/secrets/univers"} }
          , EnvFile = new Dictionary<string, string> { { "/run/secrets/question", "Answer"}, { "/run/secrets/univers", "42" } }
        };
    }

    [Test]
    public void BasicGetTest()
    {
        Assert.That(new Envtest("Question", envSim).Get(), Is.EqualTo("Answer"));
    }

    [Test]
    public void GetIntTest()
    {
        Assert.That(new Envtest("Univers", envSim).GetInt(), Is.EqualTo(42));
    }


}
