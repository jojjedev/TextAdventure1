namespace ConsoleApp2;

public class Items
{
    public string name;
    public int dmgModifier;

    public Items(string name, int dmgModifier) // Constructor för att skapa unika items direkt i Main.
    {
        this.name = name;
        this.dmgModifier = dmgModifier;
    }
}