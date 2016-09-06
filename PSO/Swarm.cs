﻿using System.Collections.Generic;

namespace PSO
{
    public class Swarm
    {
        public List<Particle> Items { get; set; } = new List<Particle>();

        /// <summary>
        /// Swarm's best known position
        /// </summary>
        public List<double> G { get; set; } = new List<double>();

        /// <summary>
        /// Function value for G set (for optimization)
        /// </summary>
        public double Fg { get; set; }
    }
}