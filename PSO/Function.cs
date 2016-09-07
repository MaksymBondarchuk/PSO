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
        public double BoundLower { get; set; }

        /// <summary>
        /// Upper boundary
        /// </summary>
        public double BoundUpper { get; set; }

        /// <summary>
        /// Function dimensions
        /// </summary>
        public double Dimensions { get; set; }
    }
}