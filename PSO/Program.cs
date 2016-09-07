using System;
using System.Linq;

namespace PSO
{
    internal static class Program
    {
        private static void Main()
        {
            var sphere = new Function
            {
                // Global min at 0*
                F = x => { return x.Sum(t => t * t); },
                BoundLower = -100,
                BoundUpper = -100
            };

            // ReSharper disable once UnusedVariable
            var ackley = new Function
            {
                // Global min at 0*
                F = x =>
                {
                    var _1NaD = 1.0 / x.Count;
                    return -20 * Math.Exp(-0.2 * Math.Sqrt(_1NaD * x.Sum(t => t * t))) -
                        Math.Exp(_1NaD * x.Sum(t => Math.Cos(2 * Math.PI * t))) + 20 + Math.E;
                },
                BoundLower = -100,
                BoundUpper = -100
            };

            // ReSharper disable once UnusedVariable
            var griewank = new Function
            {
                // Global min at 0*
                F = x =>
                {
                    var mul = 1.0;
                    for (var i = 0; i < x.Count; i++)
                        mul *= Math.Cos(x[i] / Math.Sqrt(i + 1));
                    return x.Sum(t => t * t / 4000) - mul + 1;
                },
                BoundLower = -100,
                BoundUpper = -100
            };

            // ReSharper disable once UnusedVariable
            var rastrigin = new Function
            {
                // Global min at 0*
                F = x => { return x.Sum(t => t * t - 10 * Math.Cos(2 * Math.PI * t) + 10); },
                BoundLower = -100,
                BoundUpper = -100
            };


            var algorithm = new Algorithm();
            algorithm.Run();
        }
    }
}
