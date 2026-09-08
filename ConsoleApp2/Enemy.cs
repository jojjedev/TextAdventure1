namespace ConsoleApp2;

public class Enemy 
{
    public string Name = "";
    public int Health = 10;
    private int baseDmg = 10;
    public int swipeDmg;
    public int strikeDmg;
    public int kickDmg;

    public void SetStats(Enemy enemy) // Funktionen som anropas för att göra enemies unika.
    {
        if (enemy.Name == "Minotaur")
        {
            enemy.Health = 150;
            swipeDmg = baseDmg * 2;
            kickDmg = baseDmg * 2 - 5;
            strikeDmg = baseDmg * 3;

        }

        if (enemy.Name == "Minion1")
        {
            enemy.Name = "BarnOwl";
            enemy.Health = 50;
            swipeDmg = baseDmg;
            kickDmg = baseDmg / 2;
            strikeDmg = baseDmg / 3;
        }
        if (enemy.Name == "Minion2")
        {
            enemy.Name = "Sheep";
            enemy.Health = 30;
            swipeDmg = baseDmg / 5;
            kickDmg = baseDmg;
            strikeDmg = baseDmg / 2;
        }
        if (enemy.Name == "Minion3")
        {
            enemy.Name = "Fox";
            enemy.Health = 40;
            swipeDmg = baseDmg / 2;
            kickDmg = baseDmg / 5;
            strikeDmg = baseDmg;
        }
    }

    public void AttackSwipe(Enemy enemy) // Flavour för att endast använda en attackmetod för alla enemies.
    {
        if (enemy.Name == "Minotaur")
        {
            Console.WriteLine("The Minotaur swipes his weapon at you");
        }
        else if (enemy.Name == "BarnOwl")
        {
            Console.WriteLine("The Barn owl swipes his claws at you");
        }
        else if (enemy.Name == "Sheep")
        {
            Console.WriteLine("The Sheep swipes his horns at you");
        }
        else if (enemy.Name == "Fox")
        {
            Console.WriteLine("The Fox swipes his claws at you");
        }
    }

    public void AttackKick(Enemy enemy)
    {
        if (enemy.Name == "Minotaur")
        {
            Console.WriteLine("The Minotaur attempts to kick you");
        }
        else if (enemy.Name == "BarnOwl")
        {
            Console.WriteLine("The Barn Owl attempts to kick you");
        }
        else if (enemy.Name == "Sheep")
        {
            Console.WriteLine("The Sheep attempts to kick you");
        }
        else if (enemy.Name == "Fox")
        {
            Console.WriteLine("The fox attempts to kick you");
        }
    }

    public void AttackStrike(Enemy enemy)
    {
        if (enemy.Name == "Minotaur")
        {
            Console.WriteLine("The Minotaur attempts to strike you from above");
        }else if (enemy.Name == "BarnOwl")
        {
            Console.WriteLine("The Barn Owl attempts to bite you");
        }
        else if (enemy.Name == "Sheep")
        {
            Console.WriteLine("The Sheep attempts to headbutt you");
        }
        else if (enemy.Name == "Fox")
        {
            Console.WriteLine("The Fox attempts to bite you");
        }
    }
}