using System;
using UnitTestProject;
using Xunit;

namespace XUnit_PrimeTestProject
{
    public class PrimeService_IsPrimeShould
    {
		private readonly PrimeService _primeService;

		public PrimeService_IsPrimeShould()
		{
			_primeService = new PrimeService();
		}

		[Fact]
		public void ReturnFalseGivenValueOf1()
		{
			var result = _primeService.IsPrime(1);

			Assert.False(result, "1 should not be prime");
		}

		[Fact]
		public void ReturnFalseGivenNullValue()
		{
			var result = _primeService.IsPrime(null);

			Assert.False(result, "not allowed null values");

		}

		[Fact]
		public void ReturnTrueGivenValueGreaterThan2()
		{
			var result = _primeService.IsPrime(2);

			Assert.True(result);

		}

		[Theory]
		[InlineData(-1)]
		[InlineData(0)]
		[InlineData(1)]
		public void ReturnFalseGivenValuesLessThan2(int value)
		{
			var result = _primeService.IsPrime(value);

			Assert.False(result, $"{value} should not be prime");
		}

	}
}
