using System;
using System.Collections.Generic;
using SAO.Structures;
using SAO.Structures.Mutations;

namespace SAO
{
    public class Program
    {
        static void Main(string[] args)
        {
            var routs = new Routes("0:10,1:40,2:20,3:10,4:40,5:20,6:60,7:50,8:10,9:20,10:10");
            var lines = new List<Line>
            {
                new Line("0:0,1,2,7,8,9,10"),
                new Line("1:4,6,8,9,10"),
                new Line("2:3,7,6,5"),
                new Line("3:0,1,4,5")
            };
            const int numberOfBuses = 10;
            const int busCapacity = 5;
            const int numberOfIterations = 2000;
            const int poolOfSpecimens = 100;
            IMutation mutationType = new AddAndDeductMutation(20);

            var solution = new Solution(routs, lines, mutationType, numberOfBuses, busCapacity, numberOfIterations, poolOfSpecimens);
            solution.Execute();
            Console.WriteLine(solution.BestResult.Value);
            foreach (var p in solution.BestResult.Distribution)
            {
                Console.WriteLine(p);
            }

            Console.ReadLine();
        }
    }
}
