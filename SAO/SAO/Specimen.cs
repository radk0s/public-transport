using System;
using System.Collections.Generic;
using System.Linq;

namespace SAO
{
    public class Specimen
    {

        public List<int> Distribution { get; private set; }
        public int Value { get; private set; }
        public Routes Routes { get; private set; }
        public List<Line> Lines { get; private set; }
        public int NumberOfBuses { get; private set; }
        public int BusCapacity { get; private set; }

        public Specimen(Routes routes, List<Line> lines, int numberOfBuses, int busCapacity)
        {
            Routes = routes;
            Lines = lines;
            NumberOfBuses = numberOfBuses;
            BusCapacity = busCapacity;
            SetRandomDistribution();
            CalculateSpecimentValue();
        }

        public Specimen(Specimen toClone)
        {
            Routes = toClone.Routes;
            Lines = toClone.Lines;
            NumberOfBuses = toClone.NumberOfBuses;
            BusCapacity = toClone.BusCapacity;
            CopyDistribution(toClone);
            CalculateSpecimentValue();
        }

        private void SetRandomDistribution()
        {
            Distribution = new List<int>();
            var random = new Random();
            int[] leftSpace = {Lines.Count};
            int[] sum = {0};

            foreach (var toAdd in Lines.Select(line => random.Next(1, (NumberOfBuses - sum[0]) / leftSpace[0])))
            {
                Distribution.Add(toAdd);
                sum[0] += toAdd;
                leftSpace[0] -= 1;
            }

            for (var i = 0; i < Lines.Count; i++)
            {
                var toSwap = random.Next(0, Lines.Count - 1);
                var tmp = Distribution[toSwap];
                Distribution[toSwap] = Distribution[i];
                Distribution[i] = tmp;
            }
        }

        private void CopyDistribution(Specimen toClone)
        {
            Distribution = new List<int>();
            foreach (var value in toClone.Distribution)
            {
                Distribution.Add(value);
            }
        }

        private void CalculateSpecimentValue()
        {
            var result = Routes.CreateTemporaryCopyOfRoutesValues();

            for (var i = 0; i < Lines.Count; i++)
            {
                var value = Distribution[i]*BusCapacity;
                var linesTrace = Lines[i].Trace;
                foreach (var pointOnTrace in linesTrace)
                {
                    var oldValue = result[pointOnTrace];
                    result[pointOnTrace] = oldValue - value;
                }
            }
            Value = result.Sum(val => Math.Abs(val));
        }

        public void MutateByChangingPlaces()
        {
            var random = new Random();
            var numberOfChanges = random.Next(0, Lines.Count);
            for (var i = 0; i < numberOfChanges; i++)
            {
                var first = random.Next(1, Lines.Count - 1);
                var second = random.Next(1, Lines.Count - 1);
                var temp = Distribution[first];
                Distribution[first] = Distribution[second];
                Distribution[second] = temp;
            }
            CalculateSpecimentValue();
        }

        public void Mutate()
        {
            var random = new Random();
            var toBeChanged = Lines.Select(line => random.Next(0, 100)).Select(rolled => rolled < 20 ? 1 : 0).ToList();

            for (var i = 0; i < Lines.Count; i++)
            {
                var busses = Distribution.Sum();
                var max = NumberOfBuses - busses;
                var min = -(Distribution[i] - 1);
                if (toBeChanged[i] == 1 && min < max)
                {
                    Distribution[i] += random.Next(min, max);
                }
            }
        }
    }
}
