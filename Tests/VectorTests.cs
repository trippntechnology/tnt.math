using System.Diagnostics.CodeAnalysis;
using System.Drawing;

namespace TNT.Math.Tests
{
	[ExcludeFromCodeCoverage]
	public class VectorTests
	{
		[Fact]
		public void ConstructorTests()
		{
			Vector v1 = new Vector(1.234, 5.678);
			Assert.Equal(1.234, v1.X);
			Assert.Equal(5.678, v1.Y);

			Vector v2 = new Vector(v1);
			Assert.Equal(v1, v2);

			Vector v3 = new Vector(new PointF(0, 0), new PointF(10, 10));
			Assert.Equal(new Vector(10, 10), v3);

			Assert.Equal(10, v3.X);
			Assert.Equal(10, v3.Y);

			Vector v4 = new Vector(new PointF(13, 17));

			Assert.Equal(new Vector(13, 17), v4);
		}

		[Fact]
		public void ConstructorTest_Angle()
		{
			Vector v = new Vector(new Angle(0, true), System.Math.Sqrt(100));
			Assert.Equal(0, System.Math.Round(v.X, 0));
			Assert.Equal(-10, System.Math.Round(v.Y, 0));

			v = new Vector(new Angle(45, true), System.Math.Sqrt(200));
			Assert.Equal(10, System.Math.Round(v.X, 0));
			Assert.Equal(-10, System.Math.Round(v.Y, 0));

			v = new Vector(new Angle(90, true), System.Math.Sqrt(100));
			Assert.Equal(10, System.Math.Round(v.X, 0));
			Assert.Equal(0, System.Math.Round(v.Y, 0));

			v = new Vector(new Angle(135, true), System.Math.Sqrt(200));
			Assert.Equal(10, System.Math.Round(v.X, 0));
			Assert.Equal(10, System.Math.Round(v.Y, 0));

			v = new Vector(new Angle(180, true), System.Math.Sqrt(100));
			Assert.Equal(0, System.Math.Round(v.X, 0));
			Assert.Equal(10, System.Math.Round(v.Y, 0));

			v = new Vector(new Angle(225, true), System.Math.Sqrt(200));
			Assert.Equal(-10, System.Math.Round(v.X, 0));
			Assert.Equal(10, System.Math.Round(v.Y, 0));

			v = new Vector(new Angle(270, true), System.Math.Sqrt(100));
			Assert.Equal(-10, System.Math.Round(v.X, 0));
			Assert.Equal(0, System.Math.Round(v.Y, 0));

			v = new Vector(new Angle(315, true), System.Math.Sqrt(200));
			Assert.Equal(-10, System.Math.Round(v.X, 0));
			Assert.Equal(-10, System.Math.Round(v.Y, 0));

			v = new Vector(new Angle(360, true), System.Math.Sqrt(100));
			Assert.Equal(0, System.Math.Round(v.X, 0));
			Assert.Equal(-10, System.Math.Round(v.Y, 0));

			v = new Vector(new Angle(-45, true), System.Math.Sqrt(200));
			Assert.Equal(-10, System.Math.Round(v.X, 0));
			Assert.Equal(-10, System.Math.Round(v.Y, 0));
		}

		[Fact]
		public void MagnitudeTest()
		{
			Vector v1 = new Vector(0, 17);
			Assert.Equal(17, v1.Magnitude);

			Vector v2 = new Vector(13, 0);
			Assert.Equal(13, v2.Magnitude);

			Vector v3 = v1 + v2;
			Assert.Equal(new Vector(13, 17), v3);

			Assert.Equal(21.40093, System.Math.Round(v3.Magnitude, 5));

			Vector v4 = new Vector(8, 12);
			Assert.Equal(new Vector(5, 5), v3 - v4);
			Assert.Equal(new Vector(-5, -5), v4 - v3);
		}

		[Fact]
		public void DotTest()
		{
			Vector v1 = new Vector(7, 13);
			Vector v2 = new Vector(17, 23);

			Assert.Equal(7 * 17 + 13 * 23, v1.Dot(v2));
		}

		[Fact]
		public void OperatorDotTest()
		{
			Vector v1 = new Vector(7, -13);
			Vector v2 = new Vector(17, 23);

			Assert.Equal(v1.Dot(v2), v1 * v2);
			Assert.Equal(v2.Dot(v1), v2 * v1);
		}

		[Fact]
		public void UnitVectorTest()
		{
			Vector v1 = new Vector(0, 0);
			Assert.Equal(new Vector(0, 0), v1.Unit);

			Vector v2 = new Vector(25, 0);
			Assert.Equal(new Vector(1, 0), v2.Unit);

			Vector v3 = new Vector(0, 25);
			Assert.Equal(new Vector(0, 1), v3.Unit);

			Vector v4 = new Vector(25, 25);
			Assert.Equal(System.Math.Round(.70710, 3), System.Math.Round(v4.Unit.X, 3));
			Assert.Equal(System.Math.Round(.70710, 3), System.Math.Round(v4.Unit.Y, 3));
		}

		[Fact]
		public void ToStringTest()
		{
			Vector v1 = new Vector(13.321, 17.754);
			Assert.Equal("[13.321 17.754]", v1.ToString());

			Vector v2 = new Vector(.321, .565);
			Assert.Equal("[0.321 0.565]", v2.ToString());
		}

		[Fact]
		public void OperatorMultiplyTest()
		{
			Vector v1 = new Vector(3, 7);

			Assert.Equal(new Vector(21, 49), v1 * 7);
			Assert.Equal(new Vector(27, 63), 9 * v1);
		}

		[Fact]
		public void OperatorAddTest()
		{
			PointF pf1 = new PointF(13, 17);
			Point p1 = new Point(13, 17);
			Vector v1 = new Vector(-7, -23);

			Assert.Equal(new PointF(6, -6), v1 + pf1);
			Assert.Equal(new PointF(6, -6), pf1 + v1);

			Point p1Ex = new Point(6, -6);
			Assert.Equal((PointF)p1Ex, v1 + p1);
			Assert.Equal((PointF)p1Ex, p1 + v1);
		}

		[Fact]
		public void CastingTests()
		{
			Vector v1 = new Vector(1.234, 5.678);
			PointF pf1 = v1;
			Point p1 = v1;

			Assert.Equal(new PointF((float)1.234, (float)5.678), pf1);
			Assert.Equal(new Point(1, 5), p1);
		}

		[Fact]
		public void AngleTests()
		{
			Vector v0 = new Vector(0, 0);
			Assert.Equal(new Angle(0), v0.Angle(v0));

			Vector v1 = new Vector(0, -10);
			Assert.Equal(Angle.Empty, v1.Angle(v0));
			Assert.Equal(Angle.Empty, v0.Angle(v1));

			for (double theta = 0; theta <= 180; theta += 22.5)
			{
				double thetaRad = theta / 180 * System.Math.PI;
				Vector v = new Vector(10 * System.Math.Sin(thetaRad), -10 * System.Math.Cos(thetaRad));

				Assert.Equal(theta, System.Math.Round(v.Angle(v1).InDegrees, 1));
			}

			for (double theta = 0; theta >= -180; theta -= 22.5)
			{
				double thetaRad = theta / 180 * System.Math.PI;
				Vector v = new Vector(10 * System.Math.Sin(thetaRad), -10 * System.Math.Cos(thetaRad));

				Assert.Equal(-theta, System.Math.Round(v.Angle(v1).InDegrees, 1));
			}
		}

		[Fact]
		public void AngleTests2()
		{
			Vector v1 = new Vector(new Angle(33, true), 1);
			Assert.Equal(33, System.Math.Round(v1.Angle().InDegrees));

			for (int angle = 205; angle < 220; angle++)
			{
				Vector v = new Vector(new Angle(angle, true), 1);
				Assert.Equal(angle, System.Math.Round(v.Angle().InDegrees));
				Angle a = v.Angle(v1, true);
				Assert.Equal(angle - 33, System.Math.Round(a.InDegrees));
			}
		}

		[Fact]
		public void RotateTest()
		{
			Vector origVector = new Vector(1, 0);
			Vector vector90 = origVector.Rotate(new Angle(90, true));
			Vector vector45 = origVector.Rotate(new Angle(45, true));

			Assert.Equal(0, System.Math.Round(vector90.X, 3));
			Assert.Equal(1, System.Math.Round(vector90.Y, 3));

			Assert.Equal(System.Math.Round(0.7069, 3), System.Math.Round(vector45.X, 3));
			Assert.Equal(System.Math.Round(0.7069, 3), System.Math.Round(vector45.Y, 3));
		}

		[Fact]
		public void DivideTest()
		{
			Vector vector = new Vector(27, 30);
			Vector dividend = new Vector(9, 10);

			Assert.Equal(dividend, vector / 3);
		}

		[Fact]
		public void SubtractTest()
		{
			PointF p = new PointF(21, 29);
			Vector v = new Vector(17, 11);
			Vector expected = new Vector(4, 18);

			Assert.Equal(expected.X, (p - v).X);
			Assert.Equal(expected.Y, (p - v).Y);
		}

		[Fact]
		public void NotEqual_Not_Vector()
		{
			var v = new Vector(17, 11);
			Assert.False(v.Equals(1));
		}

		[Fact]
		public void GetHash()
		{
			var v = new Vector(17, 11);
			var hash = v.GetHashCode();
			Assert.Equal(-2141782003, hash);
		}
	}
}
