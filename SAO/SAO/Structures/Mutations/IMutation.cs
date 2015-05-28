namespace SAO.Structures.Mutations
{
    public interface IMutation
    {
        Specimen Execute(Specimen specimen);
    }
}
