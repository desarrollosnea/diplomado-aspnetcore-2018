using System;

namespace UnitTestProject
{
	public class PrimeService
	{
		public bool IsPrime(int? candidate)
		{
			if (candidate == null)
			{
				return false;
			}

			if (candidate < 2)
			{
				return false;
			}
			return true;
		}
	}
}
