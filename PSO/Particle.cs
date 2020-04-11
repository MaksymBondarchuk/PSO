using System;
using System.Collections.Generic;

namespace PSO
{
	public class Particle
	{
		/// <summary>
		/// Coordinates of particle in search-space
		/// </summary>
		public List<double> X { get; } = new List<double>();

		/// <summary>
		/// function value for X set (for optimization)
		/// </summary>
		public double Fx { get; set; } = double.MaxValue;

		/// <summary>
		/// Velocity
		/// </summary>
		public List<double> V { get; } = new List<double>();

		/// <summary>
		/// The best known position
		/// </summary>
		public List<double> P { get; } = new List<double>();

		/// <summary>
		/// function value for P set (for optimization)
		/// </summary>
		public double Fp { get; private set; } = double.MaxValue;

		public void UpdateP()
		{
			P.Clear();
			P.AddRange(X);
			Fp = Fx;
		}

		public void Generate(Function func, Random random)
		{
			X.Clear();
			P.Clear();
			V.Clear();
			for (int j = 0; j < func.Dimensions; j++)
			{
				double rnd = func.BoundLower + random.NextDouble() * (func.BoundUpper - func.BoundLower);
				X.Add(rnd);
				P.Add(rnd);

				double range = Math.Abs(func.BoundUpper - func.BoundLower);
				V.Add(-range + random.NextDouble() * 2 * range);
			}

			Fx = func.F(X);
			Fp = Fx;
		}
	}
}