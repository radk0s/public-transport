﻿namespace SAO.Structures.Mutations
{
    internal class ChangePlaceMutation : IMutation
    {
        public void Execute(Specimen specimen)
        {
            var numberOfChanges = specimen.Random.Next(0, specimen.Lines.Count);
            for (var i = 0; i < numberOfChanges; i++)
            {
                var first = specimen.Random.Next(1, specimen.Lines.Count - 1);
                var second = specimen.Random.Next(1, specimen.Lines.Count - 1);
                var temp = specimen.Distribution[first];
                specimen.Distribution[first] = specimen.Distribution[second];
                specimen.Distribution[second] = temp;
            }
            specimen.CalculateSpecimentValue();
        }
    }
}