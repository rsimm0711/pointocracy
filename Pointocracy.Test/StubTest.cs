using Pointocracy.Core;

namespace Pointocracy.Test
{
    public class Tests
    {
        [Test]
        public void StubTest()
        {
            Assert.That(Stub.HelloWorld(), Is.EqualTo("Hello World!"));
        }
    }
}