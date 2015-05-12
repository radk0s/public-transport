using System.Collections.Generic;
using System.Linq;

namespace SAO
{
    public class Routes
    {
        public List<int> RoutesValues { get; private set; }

        public Routes(string routString)
        {
            RoutesValues = new List<int>();
            var splitted = routString.Split(',');
            foreach (var values in splitted.Select(rout => rout.Split(':')))
            {
                RoutesValues.Add(int.Parse(values[1]));
            }
        }

        public List<int> CreateTemporaryCopyOfRoutesValues()
        {
            return RoutesValues.ToList();
        }
    }
}
