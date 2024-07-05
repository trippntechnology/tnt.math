using System.Diagnostics.CodeAnalysis;

namespace TNT.Math.Tests
{
  [ExcludeFromCodeCoverage]
  public class AngleTests
  {
    [Test]
    public void ConstructorTests()
    {
      //try
      //{
      //  Angle a1;
      //  Assert.Throws<ArgumentException>(delegate { a1 = new Angle(-1.1); });
      //  Assert.Throws<ArgumentException>(delegate { a1 = new Angle(1.1); });
      //  a1 = new Angle(-1.1);
      //}
      //catch (ArgumentException ae)
      //{
      //  Assert.That("The angle parameter must be between 1 and -1", ae.Message);
      //}

      Angle a1 = new Angle(System.Math.PI);
      Assert.That(a1.InRadians, Is.EqualTo(System.Math.PI));
      Assert.That(a1.InDegrees, Is.EqualTo(180));

      Angle a2 = new Angle(90, true);
      Assert.That(a2.InRadians, Is.EqualTo(System.Math.PI / 2));
      Assert.That(a2.InDegrees, Is.EqualTo(90));

      Angle a3 = new Angle(System.Math.PI / 4, false);
      Assert.That(a3.InRadians, Is.EqualTo(System.Math.PI / 4));
      Assert.That(a3.InDegrees, Is.EqualTo(45));

      Angle a4 = new Angle(a3);
      Assert.That(a4.InRadians, Is.EqualTo(System.Math.PI / 4));
      Assert.That(a4.InDegrees, Is.EqualTo(45));
    }

    [Test]
    public void EmptyTest()
    {
      Assert.That(new Angle(0), Is.EqualTo(Angle.Empty));
    }

    [Test]
    public void ToStringTest()
    {
      Angle a1 = new Angle(247, true);
      Assert.That(a1.ToString(), Is.EqualTo("247"));

      Angle a2 = new Angle(12.34, true);
      Assert.That(a2.ToString(), Is.EqualTo("12.34"));
    }

    [Test]
    public void OperatorAddTest()
    {
      Angle a1 = new Angle(33, true);
      Angle a2 = new Angle(42, true);

      Angle sum = a1 + a2;

      Assert.That(System.Math.Round(sum.InDegrees, 3), Is.EqualTo(75));
    }

    [Test]
    public void NotEqual_Not_Angle()
    {
      Angle a1 = new Angle(33, true);
      Assert.That(a1.Equals(1), Is.False);
    }

    [Test]
    public void GetHash()
    {
      var a1 = new Angle(33, true);
      var hash = a1.GetHashCode();
      Assert.That(hash, Is.EqualTo(-393782082));
    }
  }
}
