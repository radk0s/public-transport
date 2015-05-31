using SAO.Structures;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAO.Util
{
    class InputDataLoader
    {
        public Tuple<Routes, List<Line>, IDictionary<String, String>> loadInput(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException(string.Format("{0} does not exists.", path));

            var data = File.ReadLines(path).Where(s => s != "");

            if (data.Count() < 2)
                throw new FormatException();

            var routes = new Routes(data.ElementAt(0));

            int linesCount = int.Parse(data.ElementAt(1));

            var lines = data.Skip(2).Take(linesCount).Select(s => new Line(s));

            var parameters = data.Skip(2).Skip(linesCount)
                .Select(s => s.Split('='))
                .ToDictionary(a => a[0], a => a[1]);

            return new Tuple<Routes, List<Line>, IDictionary<String, String>>(
                routes, lines.ToList(), parameters);
        }
    }
}
