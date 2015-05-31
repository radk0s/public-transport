using System;
using System.Collections.Generic;
using SAO.Structures;
using SAO.Structures.Crossover;
using SAO.Structures.Mutations;
using SAO.Util;

namespace SAO
{
    public class Program
    {
        static void Main(string[] args)
        {
            var loader = new InputDataLoader();

            // when run from VS, cwd is [...]/SAO/SAO/bin/Debug
            var input = loader.loadInput("../../../input/input02.txt");

            var routs = input.Item1;
            var lines = input.Item2;

            var c = input.Item3;

            int numberOfBuses      = c.GetIntOrDefault("numberOfBuses", 100);
            int busCapacity        = c.GetIntOrDefault("busCapacity", 5);
            int numberOfIterations = c.GetIntOrDefault("numberOfIterations", 40);
            int poolOfSpecimens    = c.GetIntOrDefault("poolOfSpecimens", 20);

            int mutationChance        = c.GetIntOrDefault("mutationChance", 20);
            double crossoverBernoulli = c.GetDoubleOrDefault("crossoverBernoulli", 0.5);
            int crossoverChance       = c.GetIntOrDefault("crossoverChance", 70);

            var random = new Random();

            IMutation mutationType = new RandomOrderAddAndRemoveMutation(mutationChance);
            ICrossover crossoverType = new LowerValueCrossover(crossoverBernoulli, crossoverChance, random);


            var solution = new Solution(
                routs, lines,
                mutationType,
                crossoverType,
                numberOfBuses,
                busCapacity,
                numberOfIterations,
                poolOfSpecimens,
                random);

            solution.Execute();

            Console.WriteLine("Value: " + solution.BestResult.Value);
            Console.WriteLine("Solution:");
            solution.BestResult.Distribution.ForEach(Console.WriteLine);

            Console.ReadLine();
        }
    }
}
