using System;
using System.Collections.Generic;
using System.Linq;
using SAO.Structures.Crossover;
using SAO.Structures.Mutations;

namespace SAO.Structures
{
    internal class Solution
    {
        private readonly Random _random;
        private List<Specimen> _specimens = new List<Specimen>();

        public Solution(Routes routes, List<Line> lines, IMutation mutationType, ICrossover crossoverType,
            int numberOfBusses, int busCapacity, int numberOfIteration, int poolOfSpeciemens, Random random)
        {
            Routes = routes;
            Lines = lines;
            Mutation = mutationType;
            Crossover = crossoverType;
            NumberOfBuses = numberOfBusses;
            BusCapacity = busCapacity;
            PoolOfSpeciemens = poolOfSpeciemens;
            NumberOfIterations = numberOfIteration;
            _random = random;
        }

        public Specimen BestResult { get; private set; }
        public int PoolOfSpeciemens { get; private set; }
        public int NumberOfIterations { get; private set; }
        public Routes Routes { get; private set; }
        public List<Line> Lines { get; private set; }
        public int NumberOfBuses { get; private set; }
        public int BusCapacity { get; private set; }
        public IMutation Mutation { get; private set; }
        public ICrossover Crossover { get; private set; }

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
                    Mutation.Execute(specimen);
//                    Console.WriteLine("After:");
//                    foreach (var dist in specimen.Distribution)
//                    {
//                        Console.WriteLine(dist);
//                    }
                }
                _specimens = _specimens.OrderBy(o => o.Value).ToList();
                for (var j = 0; j < PoolOfSpeciemens/2; j += 2)
                {
                    _specimens[j + PoolOfSpeciemens/2] = Crossover.Execute(_specimens[j], _specimens[j + 1]);
                }
                for (var j = PoolOfSpeciemens*3/4; j < PoolOfSpeciemens; j++)
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