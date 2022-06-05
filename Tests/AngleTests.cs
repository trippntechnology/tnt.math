using System.Diagnostics.CodeAnalysis;

namespace TNT.Math.Tests
{
	[ExcludeFromCodeCoverage]
	public class AngleTests
	{
		[Fact]
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
			//  Assert.Equal("The angle parameter must be between 1 and -1", ae.Message);
			//}

			Angle a1 = new Angle(System.Math.PI);
			Assert.Equal(System.Math.PI, a1.InRadians);
			Assert.Equal(180, a1.InDegrees);

			Angle a2 = new Angle(90, true);
			Assert.Equal(System.Math.PI / 2, a2.InRadians);
			Assert.Equal(90, a2.InDegrees);

			Angle a3 = new Angle(System.Math.PI / 4, false);
			Assert.Equal(System.Math.PI / 4, a3.InRadians);
			Assert.Equal(45, a3.InDegrees);

			Angle a4 = new Angle(a3);
			Assert.Equal(System.Math.PI / 4, a4.InRadians);
			Assert.Equal(45, a4.InDegrees);
		}

		[Fact]
		public void EmptyTest()
		{
			Assert.Equal(new Angle(0), Angle.Empty);
		}

		[Fact]
		public void ToStringTest()
		{
			Angle a1 = new Angle(247, true);
			Assert.Equal("247", a1.ToString());

			Angle a2 = new Angle(12.34, true);
			Assert.Equal("12.34", a2.ToString());
		}

		[Fact]
		public void OperatorAddTest()
		{
			Angle a1 = new Angle(33, true);
			Angle a2 = new Angle(42, true);

			Angle sum = a1 + a2;

			Assert.Equal(75, System.Math.Round(sum.InDegrees, 3));
		}

		[Fact]
		public void NotEqual_Not_Angle()
		{
			Angle a1 = new Angle(33, true);
			Assert.False(a1.Equals(1));
		}

		[Fact]
		public void GetHash()
		{
			var a1 = new Angle(33, true);
			var hash = a1.GetHashCode();
			Assert.Equal(-393782082, hash);
		}
	}
}
