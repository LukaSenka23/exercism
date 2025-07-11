public enum Allergen
{
    Eggs = 1,
    Peanuts = 2,
    Shellfish = 4,
    Strawberries = 8,
    Tomatoes = 16,
    Chocolate = 32,
    Pollen = 64,
    Cats = 128
}

public class Allergies
{
    private readonly int _mask;

    public Allergies(int mask)
    {
        _mask = mask;
    }

    public bool IsAllergicTo(Allergen allergen) => ((int)allergen & _mask) != 0;

    public Allergen[] List()
    {
        var result = new List<Allergen>();

        foreach (Allergen allergen in Enum.GetValues(typeof(Allergen)))
        {
            if ((_mask & (int)allergen) != 0)
            {
                result.Add(allergen);
            }
        }

        return result.ToArray();
    }
}