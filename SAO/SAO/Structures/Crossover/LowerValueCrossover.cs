using System.Collections.Generic;

namespace SAO.Structures.Crossover
{
    class LowerValueCrossover: ICrossover
    {
        public Specimen Execute(Specimen specimen1, Specimen specimen2)
        {
            var distribution = new List<int>();
            for (var i = 0; i < specimen1.Lines.Count; i++)
            {
                distribution.Add(specimen1.Distribution[i] <= specimen2.Distribution[i]
                    ? specimen1.Distribution[i]
                    : specimen2.Distribution[i]);
            }
            return new Specimen(specimen1, distribution);
        }
    }
}
