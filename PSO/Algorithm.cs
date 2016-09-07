using System;

namespace PSO {
    public class Algorithm {
        #region Constants: private
        private const double PhiP = 1.5;
        private const double PhiG = 2;
        #endregion

        #region Properties: private
        private Swarm Swarm { get; } = new Swarm();
        private Function Func { get; set; }

        private Random Random { get; } = new Random();
        #endregion

        private void Initialize(int swarmSize, Function func) {
            Func = func;

            Swarm.Particles.Clear();
            for (var i = 0; i < swarmSize; i++) {
                var particle = new Particle();

                for (var j = 0; j < Func.Dimensions; j++) {
                    var rnd = Func.BoundLower + Random.NextDouble() * (Func.BoundUpper - Func.BoundLower);
                    particle.X.Add(rnd);
                    particle.P.Add(rnd);

                    var range = Math.Abs(Func.BoundUpper - Func.BoundLower);
                    particle.V.Add(-range + Random.NextDouble() * 2 * range);
                }

                particle.Fx = Func.F(particle.X);
                particle.Fp = particle.Fx;

                Swarm.Particles.Add(particle);

                if (particle.Fp < Swarm.Fg)
                    Swarm.UpdateG(particle.P, Func);
            }
        }

        public void Run(int swarmSize, Function func, int iterationsNumber) {
            Initialize(swarmSize, func);

            var vMax = Math.Abs(Func.BoundUpper - Func.BoundLower) * .1;
            const double wUp = 1.0;
            const double wLow = 0.1;

            for (var iter = 0; iter < iterationsNumber; iter++) {
                var w = wUp - (wUp - wLow) * iter / iterationsNumber;

                foreach (var particle in Swarm.Particles) {
                    for (var d = 0; d < Func.Dimensions; d++) {
                        var rp = Random.NextDouble();
                        var rg = Random.NextDouble();

                        particle.V[d] = w * particle.V[d] + PhiP * rp * (particle.P[d] - particle.X[d]) +
                                        PhiG * rg * (Swarm.G[d] - particle.X[d]);

                        particle.V[d] = Math.Min(particle.V[d], vMax);
                        particle.V[d] = Math.Max(particle.V[d], -vMax);

                        particle.X[d] += particle.V[d];

                        particle.X[d] = Math.Max(particle.X[d], Func.BoundLower);
                        particle.X[d] = Math.Min(particle.X[d], Func.BoundUpper);
                    }

                    particle.Fx = Func.F(particle.X);
                    if (particle.Fx < particle.Fp) {
                        particle.UpdateP();
                        if (particle.Fp < Swarm.Fg)
                            Swarm.UpdateG(particle.P, Func);
                    }
                }

                //w *= 0.99;
                Console.WriteLine($"#{iter,-4} Best G = {Swarm.Fg,-20:0.0000000000} W = {w,-20:0.000000000}");
            }
        }
    }
}
