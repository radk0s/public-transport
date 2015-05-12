using System;
using System.Collections.Generic;
using SAO.Structures;
using SAO.Structures.Crossover;
using SAO.Structures.Mutations;

namespace SAO
{
    public class Program
    {
        static void Main(string[] args)
        {
//            var routs = new Routes("0:10,1:40,2:20,3:10,4:40,5:20,6:60,7:50,8:10,9:20,10:10");
//            var lines = new List<Line>
//            {
//                new Line("0:0,1,2,7,8,9,10"),
//                new Line("1:4,6,8,9,10"),
//                new Line("2:3,7,6,5"),
//                new Line("3:0,1,4,5")
//            };
//            const int numberOfBuses = 10;
//            const int busCapacity = 5;
//            const int numberOfIterations = 40;
//            const int poolOfSpecimens = 20;
////            IMutation mutationType = new AddAndDeductMutation(20);
//            IMutation mutationType = new RandomOrderAddAndRemoveMutation(20);
//            ICrossover crossoverType = new LowerValueCrossover();

            var routs = new Routes("0:1,1:1,2:1,3:1,4:1,5:1,6:1,7:1,8:1,9:1,10:1,11:1,12:1,13:1,14:1,15:1,16:1,17:1,18:1,19:1,20:1,21:1,22:1,23:1,24:1,25:1,26:1,27:1,28:1,29:1,30:1,31:1,32:1,33:1,34:1,35:1,36:1,37:1,38:1,39:1");
            var lines = new List<Line>
            {
                new Line("0:0,1,2,3"),
                new Line("1:4,5,6,7"),
                new Line("2:8,9,10,11"),
                new Line("3:12,13,14,15"),
                new Line("4:16,17,18,19"),
                new Line("5:20,25,30,35"),
                new Line("6:21,26,31,36"),
                new Line("7:22,27,32,37"),
                new Line("8:23,28,33,38"),
                new Line("9:24,29,34,39"),
            };
            const int numberOfBuses = 300;
            const int busCapacity = 1;
            const int numberOfIterations = 40000;
            const int poolOfSpecimens = 40;
            IMutation mutationType = new RandomOrderAddAndRemoveMutation(20);
            ICrossover crossoverType = new LowerValueCrossover();


            var solution = new Solution(routs, lines, mutationType, crossoverType, numberOfBuses, busCapacity, numberOfIterations, poolOfSpecimens);
            solution.Execute();
            Console.WriteLine("Value: " + solution.BestResult.Value);
            Console.WriteLine("Solution:");
            foreach (var p in solution.BestResult.Distribution)
            {
                Console.WriteLine(p);
            }

            Console.ReadLine();
        }
    }
}
