using System;
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
            var input = loader.loadInput("../../../input/input04.txt");

            var routs = input.Item1;
            var lines = input.Item2;
            
            var c = input.Item3;

            var numberOfBuses      = c.GetIntOrDefault("numberOfBuses", 300);
            var busCapacity        = c.GetIntOrDefault("busCapacity", 5);
            var numberOfIterations = c.GetIntOrDefault("numberOfIterations", 40);
            var poolOfSpecimens    = c.GetIntOrDefault("poolOfSpecimens", 20);

            var mutationChance        = c.GetIntOrDefault("mutationChance", 20);
            var crossoverBernoulli = c.GetDoubleOrDefault("crossoverBernoulli", 0.5);
            var crossoverChance       = c.GetIntOrDefault("crossoverChance", 10);

            var random = new Random();

            var mutationType = new RandomOrderAddAndRemoveMutation(mutationChance);
            var crossoverType = new LowerValueCrossover(crossoverBernoulli, crossoverChance, random);


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
