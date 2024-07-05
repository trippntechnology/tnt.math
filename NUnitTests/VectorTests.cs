using System.Diagnostics.CodeAnalysis;
using System.Drawing;

namespace TNT.Math.Tests
{
  [ExcludeFromCodeCoverage]
  public class VectorTests
  {
    [Test]
    public void ConstructorTests()
    {
      Vector v1 = new Vector(1.234, 5.678);
      Assert.That(v1.X, Is.EqualTo(1.234));
      Assert.That(v1.Y, Is.EqualTo(5.678));

      Vector v2 = new Vector(v1);
      Assert.That(v1, Is.EqualTo(v2));

      Vector v3 = new Vector(new PointF(0, 0), new PointF(10, 10));
      Assert.That(new Vector(10, 10), Is.EqualTo(v3));

      Assert.That(v3.X, Is.EqualTo(10));
      Assert.That(v3.Y, Is.EqualTo(10));

      Vector v4 = new Vector(new PointF(13, 17));

      Assert.That(new Vector(13, 17), Is.EqualTo(v4));
    }

    [Test]
    public void ConstructorTest_Angle()
    {
      Vector v = new Vector(new Angle(0, true), System.Math.Sqrt(100));
      Assert.That(System.Math.Round(v.X, 0), Is.EqualTo(0));
      Assert.That(System.Math.Round(v.Y, 0), Is.EqualTo(-10));

      v = new Vector(new Angle(45, true), System.Math.Sqrt(200));
      Assert.That(System.Math.Round(v.X, 0), Is.EqualTo(10));
      Assert.That(System.Math.Round(v.Y, 0), Is.EqualTo(-10));

      v = new Vector(new Angle(90, true), System.Math.Sqrt(100));
      Assert.That(System.Math.Round(v.X, 0), Is.EqualTo(10));
      Assert.That(System.Math.Round(v.Y, 0), Is.EqualTo(0));

      v = new Vector(new Angle(135, true), System.Math.Sqrt(200));
      Assert.That(System.Math.Round(v.X, 0), Is.EqualTo(10));
      Assert.That(System.Math.Round(v.Y, 0), Is.EqualTo(10));

      v = new Vector(new Angle(180, true), System.Math.Sqrt(100));
      Assert.That(System.Math.Round(v.X, 0), Is.EqualTo(0));
      Assert.That(System.Math.Round(v.Y, 0), Is.EqualTo(10));

      v = new Vector(new Angle(225, true), System.Math.Sqrt(200));
      Assert.That(System.Math.Round(v.X, 0), Is.EqualTo(-10));
      Assert.That(System.Math.Round(v.Y, 0), Is.EqualTo(10));

      v = new Vector(new Angle(270, true), System.Math.Sqrt(100));
      Assert.That(System.Math.Round(v.X, 0), Is.EqualTo(-10));
      Assert.That(System.Math.Round(v.Y, 0), Is.EqualTo(0));

      v = new Vector(new Angle(315, true), System.Math.Sqrt(200));
      Assert.That(System.Math.Round(v.X, 0), Is.EqualTo(-10));
      Assert.That(System.Math.Round(v.Y, 0), Is.EqualTo(-10));

      v = new Vector(new Angle(360, true), System.Math.Sqrt(100));
      Assert.That(System.Math.Round(v.X, 0), Is.EqualTo(0));
      Assert.That(System.Math.Round(v.Y, 0), Is.EqualTo(-10));

      v = new Vector(new Angle(-45, true), System.Math.Sqrt(200));
      Assert.That(System.Math.Round(v.X, 0), Is.EqualTo(-10));
      Assert.That(System.Math.Round(v.Y, 0), Is.EqualTo(-10));
    }

    [Test]
    public void MagnitudeTest()
    {
      Vector v1 = new Vector(0, 17);
      Assert.That(v1.Magnitude, Is.EqualTo(17));

      Vector v2 = new Vector(13, 0);
      Assert.That(v2.Magnitude, Is.EqualTo(13));

      Vector v3 = v1 + v2;
      Assert.That(new Vector(13, 17), Is.EqualTo(v3));

      Assert.That(System.Math.Round(v3.Magnitude, 5), Is.EqualTo(21.40093));

      Vector v4 = new Vector(8, 12);
      Assert.That(v3 - v4, Is.EqualTo(new Vector(5, 5)));
      Assert.That(v4 - v3, Is.EqualTo(new Vector(-5, -5)));
    }

    [Test]
    public void DotTest()
    {
      Vector v1 = new Vector(7, 13);
      Vector v2 = new Vector(17, 23);

      Assert.That(v1.Dot(v2), Is.EqualTo(7 * 17 + 13 * 23));
    }

    [Test]
    public void OperatorDotTest()
    {
      Vector v1 = new Vector(7, -13);
      Vector v2 = new Vector(17, 23);

      Assert.That(v1.Dot(v2), Is.EqualTo(v1 * v2));
      Assert.That(v2.Dot(v1), Is.EqualTo(v2 * v1));
    }

    [Test]
    public void UnitVectorTest()
    {
      Vector v1 = new Vector(0, 0);
      Assert.That(v1.Unit, Is.EqualTo(new Vector(0, 0)));

      Vector v2 = new Vector(25, 0);
      Assert.That(v2.Unit, Is.EqualTo(new Vector(1, 0)));

      Vector v3 = new Vector(0, 25);
      Assert.That(v3.Unit, Is.EqualTo(new Vector(0, 1)));

      Vector v4 = new Vector(25, 25);
      Assert.That(System.Math.Round(v4.Unit.X, 3), Is.EqualTo(System.Math.Round(.70710, 3)));
      Assert.That(System.Math.Round(v4.Unit.Y, 3), Is.EqualTo(System.Math.Round(.70710, 3)));
    }

    [Test]
    public void ToStringTest()
    {
      Vector v1 = new Vector(13.321, 17.754);
      Assert.That(v1.ToString(), Is.EqualTo("[13.321 17.754]"));

      Vector v2 = new Vector(.321, .565);
      Assert.That(v2.ToString(), Is.EqualTo("[0.321 0.565]"));
    }

    [Test]
    public void OperatorMultiplyTest()
    {
      Vector v1 = new Vector(3, 7);

      Assert.That(v1 * 7, Is.EqualTo(new Vector(21, 49)));
      Assert.That(9 * v1, Is.EqualTo(new Vector(27, 63)));
    }

    [Test]
    public void OperatorAddTest()
    {
      PointF pf1 = new PointF(13, 17);
      Point p1 = new Point(13, 17);
      Vector v1 = new Vector(-7, -23);

      Assert.That(v1 + pf1, Is.EqualTo(new PointF(6, -6)));
      Assert.That(pf1 + v1, Is.EqualTo(new PointF(6, -6)));

      Point p1Ex = new Point(6, -6);
      Assert.That(v1 + p1, Is.EqualTo((PointF)p1Ex));
      Assert.That(p1 + v1, Is.EqualTo((PointF)p1Ex));
    }

    [Test]
    public void CastingTests()
    {
      Vector v1 = new Vector(1.234, 5.678);
      PointF pf1 = v1;
      Point p1 = v1;

      Assert.That(pf1, Is.EqualTo(new PointF((float)1.234, (float)5.678)));
      Assert.That(p1, Is.EqualTo(new Point(1, 5)));
    }

    [Test]
    public void AngleTests()
    {
      Vector v0 = new Vector(0, 0);
      Assert.That(v0.Angle(v0), Is.EqualTo(new Angle(0)));

      Vector v1 = new Vector(0, -10);
      Assert.That(v1.Angle(v0), Is.EqualTo(Angle.Empty));
      Assert.That(v0.Angle(v1), Is.EqualTo(Angle.Empty));

      for (double theta = 0; theta <= 180; theta += 22.5)
      {
        double thetaRad = theta / 180 * System.Math.PI;
        Vector v = new Vector(10 * System.Math.Sin(thetaRad), -10 * System.Math.Cos(thetaRad));

        Assert.That(theta, Is.EqualTo(System.Math.Round(v.Angle(v1).InDegrees, 1)));
      }

      for (double theta = 0; theta >= -180; theta -= 22.5)
      {
        double thetaRad = theta / 180 * System.Math.PI;
        Vector v = new Vector(10 * System.Math.Sin(thetaRad), -10 * System.Math.Cos(thetaRad));

        Assert.That(-theta, Is.EqualTo(System.Math.Round(v.Angle(v1).InDegrees, 1)));
      }
    }

    [Test]
    public void AngleTests2()
    {
      Vector v1 = new Vector(new Angle(33, true), 1);
      Assert.That(System.Math.Round(v1.Angle().InDegrees), Is.EqualTo(33));

      for (int angle = 205; angle < 220; angle++)
      {
        Vector v = new Vector(new Angle(angle, true), 1);
        Assert.That(angle, Is.EqualTo(System.Math.Round(v.Angle().InDegrees)));
        Angle a = v.Angle(v1, true);
        Assert.That(angle - 33, Is.EqualTo(System.Math.Round(a.InDegrees)));
      }
    }

    [Test]
    public void RotateTest()
    {
      Vector origVector = new Vector(1, 0);
      Vector vector90 = origVector.Rotate(new Angle(90, true));
      Vector vector45 = origVector.Rotate(new Angle(45, true));

      Assert.That(System.Math.Round(vector90.X, 3), Is.EqualTo(0));
      Assert.That(System.Math.Round(vector90.Y, 3), Is.EqualTo(1));

      Assert.That(System.Math.Round(vector45.X, 3), Is.EqualTo(System.Math.Round(0.7069, 3)));
      Assert.That(System.Math.Round(vector45.Y, 3), Is.EqualTo(System.Math.Round(0.7069, 3)));
    }

    [Test]
    public void DivideTest()
    {
      Vector vector = new Vector(27, 30);
      Vector dividend = new Vector(9, 10);

      Assert.That(vector / 3, Is.EqualTo(dividend));
    }

    [Test]
    public void SubtractTest()
    {
      PointF p = new PointF(21, 29);
      Vector v = new Vector(17, 11);
      Vector expected = new Vector(4, 18);

      Assert.That((p - v).X, Is.EqualTo(expected.X));
      Assert.That((p - v).Y, Is.EqualTo(expected.Y));
    }

    [Test]
    public void NotThat_Not_Vector()
    {
      var v = new Vector(17, 11);
      Assert.That(v.Equals(1), Is.False);
    }

    [Test]
    public void GetHash()
    {
      var v = new Vector(17, 11);
      var hash = v.GetHashCode();
      Assert.That(hash, Is.EqualTo(-2141782003));
    }
  }
}
