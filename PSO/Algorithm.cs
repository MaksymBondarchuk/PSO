using System;

namespace PSO
{
    public class Algorithm
    {
        private Swarm Swarm { get; set; } = new Swarm();
        private Function Func { get; set; }

        private Random Random { get; } = new Random();

        private void Initialize(int swarmSize, int dimensions, Function func)
        {
            Func = func;
            for (var i = 0; i < swarmSize; i++)
            {
                var particle = new Particle();

                for (var j = 0; j < dimensions; j++)
                {
                    var rnd = Func.BoundLower + Random.NextDouble() * (Func.BoundUpper - Func.BoundLower);
                    particle.X.Add(rnd);
                    particle.P.Add(rnd);

                    var range = Math.Abs(Func.BoundUpper - Func.BoundLower);
                    particle.V.Add(-range + Random.NextDouble() * 2 * range);
                }

                particle.Fx = Func.F(particle.X);
                particle.Fp = particle.Fx;

                Swarm.Items.Add(particle);

                if (particle.Fp < Swarm.Fg)
                    Swarm.UpdateG(particle.P, Func);
            }
        }

        public void Run(int swarmSize, int dimensions, Function func)
        {
            Initialize(swarmSize, dimensions, func);
        }
    }
}
