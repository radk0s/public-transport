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

        public void Execute(Specimen specimen)
        {
            var numberOfItemsToChanged =
                specimen.Lines.Select(line => specimen.Random.Next(0, 100))
                    .Select(rolled => rolled < _chance ? 1 : 0)
                    .ToList();

            var toBeChanged = new List<int>();
            for (var i = 0; i < specimen.Lines.Count; i++)
            {
                if (numberOfItemsToChanged[i] != 1) continue;
                var value = specimen.Random.Next(0, specimen.Lines.Count - 1);
                if (!toBeChanged.Contains(value))
                {
                    toBeChanged.Add(value);
                }
            }

            foreach (var i in toBeChanged)
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
        }
    }
}
