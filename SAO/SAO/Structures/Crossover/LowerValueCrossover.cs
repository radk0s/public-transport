using System;
using System.Collections.Generic;
using Meta.Numerics.Statistics.Distributions;

namespace SAO.Structures.Crossover
{
    class LowerValueCrossover: ICrossover
    {

        private readonly double _chance;
        private readonly int _probability;
        private readonly Random _random;

        public LowerValueCrossover(double bernoulliParameter, int probability, Random random)
        {
            if (bernoulliParameter > 1 || bernoulliParameter < 0 || probability < 0 || probability > 100)
            {
                throw new ArgumentException();
            }
            _chance = bernoulliParameter;
            _random = random;
            _probability = probability;
        }

        public Specimen Execute(Specimen specimen1, Specimen specimen2)
        {
            if (_random.Next(0, 100) >= _probability)
            {
                return specimen1.Value < specimen2.Value ? new Specimen(specimen1) : new Specimen(specimen2);
            }

            var bernoulliDistribution = new BernoulliDistribution(_chance);

            var distribution = new List<int>();
            for (var i = 0; i < specimen1.Lines.Count; i++)
            {
                distribution.Add(specimen1.Distribution[i] <= specimen2.Distribution[i] && bernoulliDistribution.GetRandomValue(_random) == 1
                    ? specimen1.Distribution[i]
                    : specimen2.Distribution[i]);
            }
            return new Specimen(specimen1, distribution);
        }
    }
}
