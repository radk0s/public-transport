using System;
using System.Linq;

namespace SAO.Structures.Mutations
{
    public class AddAndRemoveMutation : IMutation
    {
        private readonly int _chance;

        public AddAndRemoveMutation(int percentageChance)
        {
            if (percentageChance < 0 || percentageChance > 100)
            {
                throw new ArgumentException();
            }
            _chance = percentageChance;
        }

        public void Execute(Specimen specimen)
        {
            var toBeChanged =
                specimen.Lines.Select(line => specimen.Random.Next(0, 100))
                    .Select(rolled => rolled < _chance ? 1 : 0)
                    .ToList();

            for (var i = 0; i < specimen.Lines.Count; i++)
            {
                var busses = specimen.Distribution.Sum();
                var max = specimen.NumberOfBuses - busses;
                var min = -(specimen.Distribution[i] - 1);
                if (toBeChanged[i] == 1 && min < max)
                {
                    specimen.Distribution[i] += specimen.Random.Next(min, max);
                }
            }
            specimen.CalculateSpecimentValue();
        }
    }
}