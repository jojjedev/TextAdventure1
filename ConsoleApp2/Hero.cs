using System.Runtime.CompilerServices;

namespace ConsoleApp2;

public class Hero
{
    public string Name = "";
    public int Health = 100;
    public List<string> Items = new List<string>();
    public string Location = "newgame";
    public int baseDmg = 10;
    public int currentDmg;
    
    public static void SetDmg(Hero hero)
    
    {
        int modifier = 0;
        if (hero.Items.Contains("Shiny Sword"))
        {
            modifier += 10;
        }

        if (hero.Items.Contains("Magical chef's hat"))
        {
            modifier += 5;
        }

        if (hero.Items.Contains("Cursed chef's hat"))
        {
            modifier -= 5;
        }

        hero.currentDmg = hero.baseDmg + modifier;
    }
}