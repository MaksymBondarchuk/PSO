using System;
using System.Collections.Generic;

namespace PSO
{
    public class Function
    {
        /// <summary>
        /// Function
        /// </summary>
        public Func<List<double>, double> F;

        /// <summary>
        /// Lower boundary
        /// </summary>
        public double BoundLower;

        /// <summary>
        /// Upper boundary
        /// </summary>
        public double BoundUpper;
    }
}