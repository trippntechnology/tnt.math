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
      Assert.That(System.Math.PI, Is.EqualTo(a1.InRadians));
      Assert.That(180, Is.EqualTo(a1.InDegrees));

      Angle a2 = new Angle(90, true);
      Assert.That(System.Math.PI / 2, Is.EqualTo(a2.InRadians));
      Assert.That(90, Is.EqualTo(a2.InDegrees));

      Angle a3 = new Angle(System.Math.PI / 4, false);
      Assert.That(System.Math.PI / 4, Is.EqualTo(a3.InRadians));
      Assert.That(45, Is.EqualTo(a3.InDegrees));

      Angle a4 = new Angle(a3);
      Assert.That(System.Math.PI / 4, Is.EqualTo(a4.InRadians));
      Assert.That(45, Is.EqualTo(a4.InDegrees));
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
      Assert.That("247", Is.EqualTo(a1.ToString()));

      Angle a2 = new Angle(12.34, true);
      Assert.That("12.34", Is.EqualTo(a2.ToString()));
    }

    [Test]
    public void OperatorAddTest()
    {
      Angle a1 = new Angle(33, true);
      Angle a2 = new Angle(42, true);

      Angle sum = a1 + a2;

      Assert.That(75, Is.EqualTo(System.Math.Round(sum.InDegrees, 3)));
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
