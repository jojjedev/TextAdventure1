using System.Runtime.CompilerServices;

namespace ConsoleApp2;

public class Hero
{
    public string Name = "";
    public int Health = 100;
    public string Location = "newgame";
    public int baseDmg = 10;
    public int currentDmg;
    
    /*
    public static void SetDmg(Hero hero, List<Items> inventory, string itemName)
    
    {
        
        
        for (int i = 0; i < inventory.Count(); i++)
        {
            if (SearchInventory(inventory, "shinySword"))
            {
                hero.currentDmg = hero.baseDmg + inventory[i].dmgModifier;
            }
        }
        for (int i = 0; i < inventory.Count(); i++)
        {
            if (SearchInventory(inventory, "magicalHat"))
            {
                hero.currentDmg = hero.baseDmg + inventory[i].dmgModifier;
            }
        }
        for (int i = 0; i < inventory.Count(); i++)
        {
            if (SearchInventory(inventory, "cursedHat"))
            {
                hero.currentDmg = hero.baseDmg + inventory[i].dmgModifier;
            }
        }
        int modifier = 0;
        if (SearchInventory(inventory, "shinySword"))
        {
            modifier += inventory[1].dmgModifier;
            
        }

        if (hero.items.Contains("Magical chef's hat"))
        {
            modifier += 5;
        }

        if (hero.items.Contains("Cursed chef's hat"))
        {
            modifier -= 5;
        }
        

        hero.currentDmg = hero.baseDmg + modifier;
    }
    

    private static bool SearchInventory(List<Items> inventory, string itemName)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].name == itemName)
            {
                return true;
            }
        }
        return false;
    }
    */ // Ursprungliga försöket till att använda funktioner i classen.
}