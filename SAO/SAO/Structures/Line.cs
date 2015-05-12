using System.Collections.Generic;

namespace SAO.Structures
{
    public class Line
    {
        private readonly List<int> _trace = new List<int>();

        public List<int> Trace
        {
            get { return _trace; }
        }

        public int LineId { get; private set; }

        public Line(string lineString)
        {
            var splitted = lineString.Split(':');

            LineId = int.Parse(splitted[0]);
            foreach (var pointOnTrace in splitted[1].Split(','))
            {
                _trace.Add(int.Parse(pointOnTrace));
            }
        }
    }
}
