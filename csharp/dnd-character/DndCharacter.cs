public class DndCharacter
{
    public int Strength { get; private set; }
    public int Dexterity { get;  private set;}
    public int Constitution { get;  private set;}
    public int Intelligence { get;  private set;}
    public int Wisdom { get;  private set;}
    public int Charisma { get; private set; }
    public int Hitpoints { get;  private set;}

    private static Random rnd = new Random();

    public static int Modifier(int score)
    {
        return (int)Math.Floor((score - 10) / 2.0);
    }

    public static int Ability()
    {
        var rolls = new int[4];
        for (int i = 0; i < 4; i++)
        {
            rolls[i] = rnd.Next(1, 7);
        }

        return rolls.OrderByDescending(r => r).Take(3).Sum();
    }

    public static DndCharacter Generate()
    {
        var character =  new DndCharacter
        {
            Strength = Ability(),
            Dexterity = Ability(),
            Constitution = Ability(),
            Intelligence = Ability(),
            Wisdom = Ability(),
            Charisma = Ability(),
        };
        character.Hitpoints = 10 + Modifier(character.Constitution);
        return character;
    }
}
