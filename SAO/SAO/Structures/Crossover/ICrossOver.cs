namespace SAO.Structures.Crossover
{
    public interface ICrossover
    {
        Specimen Execute(Specimen specimen1, Specimen specimen2);
    }
}
