abstract class Character
{
    protected Character(string characterType)
    { }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable()
    {
        return false;
    }

    public override string ToString()
    {
        return $"Character is a {GetType().Name}";
    }
}

class Warrior : Character
{
    
    public Warrior() : base("") { }

    public override int DamagePoints(Character target)
    {
        if (target.Vulnerable())
        {
            return 10;
        }
        else
            return 6;
    }
    
}

class Wizard : Character
{
    private bool spellPrepared = false;
    public Wizard() : base("") { }

    public override int DamagePoints(Character target)
    {
        if (spellPrepared)
        {
            return 12;
        }
        else
            return 3;
    }
    
    public void PrepareSpell()
    {
        spellPrepared = true;
    }
    
    public override bool Vulnerable()
    {
        return !spellPrepared;
    }

}
