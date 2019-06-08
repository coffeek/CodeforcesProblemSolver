using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Olymp.Tests
{
  [TestClass]
  public class UtilsTests
  {
    [TestMethod]
    public void IsPrimeTests()
    {
      Assert.IsFalse(Utils.IsPrime(-199));
      Assert.IsFalse(Utils.IsPrime(-1));
      Assert.IsFalse(Utils.IsPrime(0));
      Assert.IsFalse(Utils.IsPrime(1));
      Assert.IsTrue(Utils.IsPrime(2));
      Assert.IsTrue(Utils.IsPrime(3));
      Assert.IsFalse(Utils.IsPrime(4));
      Assert.IsTrue(Utils.IsPrime(199));
      Assert.IsFalse(Utils.IsPrime(200));
    }
  }
}
