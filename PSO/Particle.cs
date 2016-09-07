using System;
using System.Collections.Generic;

namespace PSO
{
    public class Particle
    {
        /// <summary>
        /// Coordinates of particle in search-space
        /// </summary>
        public List<double> X { get; set; } = new List<double>();

        /// <summary>
        /// Function value for X set (for optimization)
        /// </summary>
        public double Fx { get; set; } = double.MaxValue;

        /// <summary>
        /// Velocity
        /// </summary>
        public List<double> V { get; set; } = new List<double>();

        /// <summary>
        /// The best known position
        /// </summary>
        public List<double> P { get; set; } = new List<double>();

        /// <summary>
        /// Function value for P set (for optimization)
        /// </summary>
        public double Fp { get; set; } = double.MaxValue;

        public void UpdateP()
        {
            P.Clear();
            P.AddRange(X);
            Fp = Fx;
        }
    }
}
