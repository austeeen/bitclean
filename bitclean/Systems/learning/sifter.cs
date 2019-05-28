using System;

/*
 * bitclean: /system/sifterbitclean.cs
 * author: Austin Herman
 * 5/8/2019
 */

namespace bitclean
{

	class Sifter
	{
		private readonly AttributeStatistics[] dustStats;
        private Linear sizeLinear; // edgeLinear, densityLinear;
        private Logistic sizeLogistic; // edgeLogistic, densityLogistic;

        readonly double tolerance = .001;

		//	[0] size | [1] edges | [2] density
		public Sifter(AttributeStatistics[] dustStats) { this.dustStats = dustStats; }

		public int Sift(double[] data)
		{
			int output = 0;
			// calculate size value
			// calculate edge ratio value
			// calculate density value

			// add together

			return output;
		}

		private void SetUpFunctions()
		{
			// set up size piecewise functions
			sizeLinear = new Linear(1.0 / dustStats[0].avg, -1);
			sizeLogistic = new Logistic();
			GenerateLogisticParameters(sizeLogistic, dustStats[0]);
			// set up edge ratio piecewise functions

			// set up density inverted piecewise functions
		}

		public void GenerateLogisticParameters(Logistic func, AttributeStatistics stats)
		{
            // we want sifter to use the statistics from the object data to generate 
            // a logistic curve such that the 90% mark is roughly equal to the max
            // value for this parameter (size, density, edge ratio, hue, etc) and
            // the 50% mark is roughly equal to zero. This will also force the 10%
            // mark to equal -(90%)


			// set initial generic parameter values
			func.b = .001;  // beta generic
			func.c = 2;     // c generic
			func.a = Math.Exp(stats.avg * func.b);  // alpha generic

			double ninetyPercentVal;
			double zeroPercentVal;

			do
			{
                // get 90% point correct within a certain tolerance
				double calculated = 0.0;
				do
				{   // approximate beta parameter
					calculated = func.Activate(stats.max);
					if (calculated < .9) {
						// increase beta by half the difference
						func.b += Math.Abs(.9 - calculated) / 2;
					}
					else if (calculated > .9) {
						// decrease beta by half the difference
						func.b -= Math.Abs(.9 - calculated) / 2;
					}
				} while (!(calculated > (.9 - tolerance) && calculated < (.9 + tolerance)));

				double k = 0.0;
				do
				{   // get 50% point = 0 by approximating k parameter
                    // to calculate alpha parameter
					calculated = func.Activate(stats.avg);
					if (calculated < 0) {
						// increase k by half the difference
						k += Math.Abs(0 - calculated) / 2;
					}
					else if (calculated > 0) {
						// decrease k by half the difference
						k -= Math.Abs(0 - calculated) / 2;
					}
					func.a = Math.Exp(stats.avg * func.b - k);
				} while (!(calculated > (0 - tolerance) && calculated < (0 + tolerance)));

				// recalculate 90% and 0% values
				ninetyPercentVal = func.Activate(stats.max);
				zeroPercentVal = func.Activate(stats.avg);

				// check each, repeat approximations if either are off
                // this is necessary because alpha and beta affect each other
			} while (!(ninetyPercentVal > (.9 - tolerance) && ninetyPercentVal < (.9 + tolerance))
				&& !(zeroPercentVal > (0 - tolerance) && zeroPercentVal < (0 + tolerance)));
		}

	}
}
