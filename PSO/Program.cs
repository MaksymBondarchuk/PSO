using System;
using System.Linq;

namespace PSO {
    internal static class Program {
        private static void Main() {
            // ReSharper disable once UnusedVariable
            var sphere = new Function {
                F = x => { return x.Sum(t => t * t); },
                BoundLower = -100,
                BoundUpper = 100,
                Dimensions = 50
            };

            // ReSharper disable once UnusedVariable
            var ackley = new Function {
                F = x =>
                {
                    var _1NaD = 1.0 / x.Count;
                    return -20 * Math.Exp(-0.2 * Math.Sqrt(_1NaD * x.Sum(t => t * t))) -
                        Math.Exp(_1NaD * x.Sum(t => Math.Cos(2 * Math.PI * t))) + 20 + Math.E;
                },
                BoundLower = -32.768,
                BoundUpper = 32.768,
                Dimensions = 20
            };

            // ReSharper disable once UnusedVariable
            var griewank = new Function {
                F = x =>
                {
                    var mul = 1.0;
                    for (var i = 0; i < x.Count; i++)
                        mul *= Math.Cos(x[i] / Math.Sqrt(i + 1));
                    return x.Sum(t => t * t / 4000) - mul + 1;
                },
                BoundLower = -600,
                BoundUpper = 600,
                Dimensions = 50
            };

            // ReSharper disable once UnusedVariable
            var rastrigin = new Function {
                F = x => { return x.Sum(t => t * t - 10 * Math.Cos(2 * Math.PI * t) + 10); },
                BoundLower = -5.12,
                BoundUpper = 5.12,
                Dimensions = 30
            };

            // ReSharper disable once UnusedVariable
            var rosenbrock = new Function {
                F = x =>
                {
                    var res = .0;
                    for (var i = 0; i < x.Count - 1; i++)
                        res += 100 * Math.Pow(x[i + 1] - x[i] * x[i], 2) + (x[i] - 1) * (x[i] - 1);
                    return res;
                },
                BoundLower = -2.048,
                BoundUpper = 2.048,
                Dimensions = 30
            };


            var algorithm = new Algorithm();
            algorithm.Run(swarmSize: 50, func: ackley, iterationsNumber: 10000);

            //Console.WriteLine(griewank.F(new List<double> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }));
        }
    }
}
