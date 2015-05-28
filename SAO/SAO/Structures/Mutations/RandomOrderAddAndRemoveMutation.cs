using System;
using System.Collections.Generic;
using System.Linq;

namespace SAO.Structures.Mutations
{
    class RandomOrderAddAndRemoveMutation: IMutation
    {
        private readonly int _chance;

        public RandomOrderAddAndRemoveMutation(int percentageChance)
        {
            if (percentageChance < 0 || percentageChance > 100)
            {
                throw new ArgumentException();
            }
            _chance = percentageChance;
        }

        public Specimen Execute(Specimen specimen)
        {
            var changeMask =
                specimen.Lines.Select(line => specimen.Random.Next(0, 100))
                    .Select(rolled => rolled < _chance ? 1 : 0)
                    .ToList();

            var linesToChange = new List<int>();
            for (var i = 0; i < specimen.Lines.Count; i++)
            {
                if (changeMask[i] != 1) continue;
                var value = specimen.Random.Next(0, specimen.Lines.Count - 1);
                if (!linesToChange.Contains(value))
                {
                    linesToChange.Add(value);
                }
            }

            foreach (var i in linesToChange)
            {
                var busses = specimen.Distribution.Sum();
                var max = specimen.NumberOfBuses - busses;
                var min = -(specimen.Distribution[i] - 1);
                if (min < max)
                {
                    specimen.Distribution[i] += specimen.Random.Next(min, max);
                }
            }
            specimen.CalculateSpecimentValue();
            return specimen;
        }
    }
}
