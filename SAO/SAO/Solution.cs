using System;
using System.Collections.Generic;
using System.Linq;

namespace SAO
{
    class Solution
    {

        public Specimen BestResult { get; private set; }
        public int PoolOfSpeciemens { get; private set; }
        public int NumberOfIterations { get; private set; }
        public Routes Routes { get; private set; }
        public List<Line> Lines { get; private set; }
        public int NumberOfBuses { get; private set; }
        public int BusCapacity { get; private set; }
        private List<Specimen> _specimens = new List<Specimen>();
        private readonly Random _random = new Random();

        public Solution(Routes routes, List<Line> lines, int numberOfBusses, int busCapacity, int numberOfIteration, int poolOfSpeciemens)
        {
            Routes = routes;
            Lines = lines;
            NumberOfBuses = numberOfBusses;
            BusCapacity = busCapacity;
            PoolOfSpeciemens = poolOfSpeciemens;
            NumberOfIterations = numberOfIteration;
        }

        public void Execute()
        {
            for (var i = 0; i < PoolOfSpeciemens; i++)
            {
                _specimens.Add(new Specimen(Routes, Lines, NumberOfBuses, BusCapacity, _random));
            }
            BestResult = new Specimen(_specimens[0]);
            FindBest();
            for (var i = 0; i < NumberOfIterations; i++)
            {
                foreach (var specimen in _specimens)
                {
//                    Console.WriteLine("Before:");
//                    foreach (var dist in specimen.Distribution)
//                    {
//                        Console.WriteLine(dist);
//                    }
                    specimen.Mutate();
//                    Console.WriteLine("After:");
//                    foreach (var dist in specimen.Distribution)
//                    {
//                        Console.WriteLine(dist);
//                    }
                }
                _specimens = _specimens.OrderBy(o => o.Value).ToList();
                for (var j = PoolOfSpeciemens/2; j < PoolOfSpeciemens; j++)
                {
                    _specimens[j] = new Specimen(Routes, Lines, NumberOfBuses, BusCapacity, _random);
                }
                FindBest();
            }
        }

        private void FindBest()
        {
            foreach (var speciment in _specimens.Where(speciment => speciment.Value < BestResult.Value))
            {
                BestResult = new Specimen(speciment);
            }
        }

    }
}
