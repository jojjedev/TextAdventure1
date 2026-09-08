namespace ConsoleApp2;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Welcome to Text Adventure!");
        Console.ReadLine();
        string name = "";
        Hero hero = new Hero(); // Skapar spelaren
        List <Items> inventory = new List<Items>(); // Skapar en lista för Item objekt som fylls på alternativt töms senare i spelet, agerar som spelarens inventory

        while (hero.Location != "quit") //Läser av "Location" variabeln i Hero objektet, använder den för att anropa aktuella rummet(funktionen)
        {
            if (hero.Location == "newgame")
            {
                NewGame(hero);
            }
            else if (hero.Location == "tableroom")
            {
                TableRoom(hero, inventory);
            }
            else if (hero.Location == "corridor")
            {
                Corridor(hero, inventory);
            }
            else if (hero.Location == "kitchen")
            {
                Kitchen(hero, inventory);
            }
            else if (hero.Location == "lockedroom")
            {
                LockedRoom(hero, inventory);
            }
            else if (hero.Location == "courtyard")
            {
                Courtyard(hero);
            }
            else if (hero.Location == "barn")
            {
                Barn(hero);
            }
            else if (hero.Location == "barnfight")
            {
                BarnFight(hero, inventory);
            }
            else if (hero.Location == "backroom")
            {
                BackRoom(hero, inventory);
            }
            else if (hero.Location == "church")
            {
                Church(hero);
            }
            else if (hero.Location == "vault")
            {
                Vault(hero);
            }
            else if (hero.Location == "basement")
            {
                Basement(hero);
            }
            else if (hero.Location == "gameover")
            {
                GameOver(hero, inventory);
            }
            else
            {
                Console.Error.WriteLine($"You forgot to implement '{hero.Location}'!");
            }
        }
        
        Console.WriteLine("\nThank you for playing!");
    }

    static string Ask(string question)
    {
        string response;
        do
        {
            Console.Write(question);
            response = Console.ReadLine().Trim().ToLower();
            
        } while (response == "");

        return response;
    }

    static bool AskYesOrNo(string question)
    {
        while (true)
        {
            string response = Ask(question).ToLower();
            switch (response)
            {
                case "yes":
                    case "ok":
                        return true;
                case "no":
                    return false;
            }
        }
    }

    static int RollD6()
    {
        Random random = new Random();
        int roll = random.Next(1, 7);
        return roll;
    }

    static void NewGame(Hero hero)
    {
        Console.Clear();
        string name = "";
        do
        {
            name = Ask("What is your name, adventurer? ");
        } while (!AskYesOrNo($"So, {name} it is? "));

        hero.Name = name;
        hero.Location = "tableroom"; //efter varje rum så ändras Spelarens location variabel, och detta används i den tidiagre metoden som anropar location funktioner
    }
    static void TableRoom(Hero hero, List<Items> inventory)
    {
        Console.Clear();
        Items woodenSword = new Items("woodenSword", 0); // Skapar ett item objekt, anger namnet "woodenSword" och modifier "0" för enbart detta objektet.
        inventory.Add(woodenSword); // Lägger till woodenSword objektet till Inventory listan
        Console.WriteLine("You are equipped with one wooden sword, and your task " +
                          "is to slay the monster at the end of the adventure. " +
                          "" +
                          "\nIn front of you is a stone table with two items on it, " +
                          "a knife and a key." +
                          "" +
                          "\nYou can only pick up one of these items.");
        while(true) {
            string response = Ask("What item to do prefer? ");
            if (response == "knife")
            {
                Items knife = new Items("knife", 3);
                inventory.Add(knife);
                inventory.Remove(woodenSword); // Tar baort "woodenSword" objektet från listan
                hero.currentDmg += knife.dmgModifier; // Updaterar Spelarens nuvarande damage värde
                Console.WriteLine("\nYou have picked up the Knife! ");
                Console.WriteLine("It has been added to your inventory! ");
                break;
            }
            else if (response == "key")
            {
                Items key = new Items("key", 0);
                inventory.Add(key);
                Console.WriteLine("\nYou have picked up the Key! ");
                Console.WriteLine("It has been added to your inventory! ");
                break;
            }
            else if (response == "none")
            {
                Console.WriteLine("Alright, you leave empty handed");
                break;
            }
            else
            {
                Console.WriteLine("I didn't understand? ");
            }
            
            
        }
        Console.WriteLine("\n\nYou leave the room and enter the corridor.");
        Console.ReadLine();
        Console.Clear();
        hero.Location = "corridor";
    }

    static void Corridor(Hero hero, List<Items> inventory)
    {
        Console.WriteLine("You exit the room and find yourself standing in a dark hallway. " +
                          "\nYou can either enter another room on your right " + "side, " +
                          "or continue down the hallway on your left.");
        string response = Ask("Which door do you want to enter? ");
        Console.Clear();
        if (response == "left")
        {
            if (SearchItem(inventory, "key"))
            {
                Console.WriteLine("The door seems to be locked. You try the key you found in the tableroom and it works!" +
                                  "\n\nYou open the door and enter the room.");
                Console.Read();
                hero.Location = "lockedroom";
                removeItem(inventory, "key");
                
            }
            else
            {
                Console.WriteLine("The door seems to be locked.");
                Console.WriteLine("You proceed to the room on the right.");
                Console.Read();
                hero.Location = "kitchen";
            }
        }
        else if (response == "right")
        {
            Console.WriteLine("You enter into the kitchen.");
            hero.Location = "kitchen";
        }
        
    }

    static void LockedRoom(Hero hero, List<Items> inventory)
    {
        Console.Clear();
        Console.WriteLine("Inside the locked room... " +
                          "you find a shiny sword! ");
        if (AskYesOrNo("Do you want to swap your wooden sword? "))
        {
            Items shinySword = new Items("shinySword", 10);
            removeItem(inventory, "woodenSword");
            hero.currentDmg = hero.baseDmg;
            inventory.Add(shinySword);
            hero.currentDmg += shinySword.dmgModifier;
        }
        Console.WriteLine("\nYou exit out into the corridor and enter the last door at the end ");
        Console.Read();
        Console.Clear();
        hero.Location = "kitchen";

    }

    static void Kitchen(Hero hero, List<Items> inventory)
    {
        Console.WriteLine("In the kitchen you see a closed chest, it does not seem to be locked.");
        if (AskYesOrNo("Do you want to open the chest?"))
        {
            Console.WriteLine("\nYou see a chef's hat with a strange symbol of what looks like a spatula ");
            if (AskYesOrNo("Do you grab the chef's hat? "))
            {
                if (RollD6() >= 3)
                {
                    Console.WriteLine("\nThe chef's hat is indeed magical, you feel inspired");
                    Items magicalHat = new Items("magicalHat", 5);
                    hero.currentDmg += magicalHat.dmgModifier;
                    inventory.Add(magicalHat);
                }
                else
                {
                    Console.WriteLine("\nYou get a wierd feeling from touching the hat");
                    Items cursedHat = new Items("cursedHat", -5);
                    hero.currentDmg -= cursedHat.dmgModifier;
                    inventory.Add(cursedHat);
                }
            }
            else
            {
                Console.WriteLine("\nSomething about the hat doesn't feel right, you decide to ignore it");
            }
        }

        Console.ReadLine();
        Console.Clear();
        Console.WriteLine("You exit the kitchen and you enter into a massive courtyard");
        Console.Read();
        Console.Clear();
        hero.Location = "courtyard";
    }

    static void Courtyard(Hero hero)
    {
        Console.WriteLine("The courtyard is dark and path is leading away from the house. \nUp ahead it splits in two directions," +
                          "one path towards the church and another path towards the barn.");
        while (true)
        {
            string response = Ask("Do you walk towards the CHURCH or the BARN?");
            if (response == "church")
            {
                Console.WriteLine("You get a strange feeling as you aproach the chruch." +
                                  "\nThere is candle light glowing in the windows, even though it's long since abandoned." +
                                  "\nAs you get close, you realise that the door looks even bigger than you thought. \nYou decide" +
                                  "to investigate and open the door.");
                hero.Location = "church";
                break;
            }
            else if (response == "barn")
            {
                Console.WriteLine("You head towards the barn.");
                hero.Location = "barn";
                break;
            }

            Console.Read(); // Fråga om varför denna read metoden skippades utan if satsen över.
        }
    }

    static void Barn(Hero hero)
    {
        Console.WriteLine("You enter into the barn. It is dark and there seems to be a room at the end.");
        string response = Ask("Do you want to explore the ROOM in the barn or turn back towards the CHURCH?");
        if (response == "room")
        {
            hero.Location = "barnfight";
        }
        else if (response == "church")
        {
            hero.Location = "church";
        }
    }

    static void BarnFight(Hero hero, List<Items> inventory)
    {
        List <Enemy> enemies = new List<Enemy>(); // Skapar en lista för Enemy objekt
        for (int i = 0; i < 3; i++) // Denna loopen fyller listan med 3 olika Enemy objekt.
        {
            Enemy enemy = new Enemy();
            enemy.Name = $"Minion{i+1}"; //Namnger varje objekt till minion + loopens nuvarande loop
            enemy.SetStats(enemy); // I denna funktionen ändras varje enemy objekt till sin unika version
            enemies.Add(enemy);
        }
        
        for(; enemies.Count() > 0; )
        {
            while (enemies[0].Health > 0)
            {
                EnemyTurn(hero, enemies[0]);
                PlayerTurn(hero, enemies[0]);
                if (hero.Health <= 0)
                {
                    Console.WriteLine("The final hit brings you to a knee, and you fall unconscious");
                    Console.ReadLine();
                    hero.Location = "gameover";
                }
            }
            enemies.Remove(enemies[0]);
        }
        Console.WriteLine("You manage take down the animals! You decide to investigate the room in the back of the barn.");
        Console.ReadLine();
        hero.Location = "backroom";
    }

    static void BackRoom(Hero hero, List<Items> inventory)
    {
        Console.WriteLine("You are in the backroom");
        Console.ReadLine();
        
        Console.WriteLine("You see a shiny set of armor");
        if (AskYesOrNo("Do you wish to equip it?"))
        {
            hero.Health += 50;
            Items shinyArmor = new Items("shinyArmor", 0);
            inventory.Add(shinyArmor);
        }
        Console.WriteLine("You also see a potion with a red liquid in it");
        if (AskYesOrNo("Do you drink the potion?"))
        {
            int result = RollD6();
            if (hero.Health == 150)
            {
                Console.WriteLine("You have not recieved any damage so the potion has no effect");
            }
            else if (result <= 2)
            {
                Console.WriteLine("The potion tastes good but has clearly been here for awhile and the effect i greatly reduced");
                hero.Health += 10;
                if (hero.Health >= 150)
                {
                    hero.Health = 150;
                    Console.WriteLine("You are now at full HP!");
                }
                else
                {
                    Console.WriteLine($"You have {hero.Health} HP!");
                }
            }
            else if (result > 2 && result <= 4)
            {
                Console.WriteLine("The potion creates a warm feeling inside you, but does not feel fully potent");
                hero.Health += 20;
                if (hero.Health >= 150)
                {
                    hero.Health = 150;
                    Console.WriteLine("You are now at full HP!");
                }
                else
                {
                    Console.WriteLine($"You have {hero.Health} HP!");
                }
            }
            else
            {
                Console.WriteLine("The potion fills you with warmth and a surge of energy ");
                hero.Health += 30;
                if (hero.Health >= 150)
                {
                    hero.Health = 150;
                    Console.WriteLine("You are now at full HP!");
                }
                else
                {
                    Console.WriteLine($"You have {hero.Health} HP!");
                }
            }
        }
        Console.WriteLine("After gathering your things, you decide to head towards the church.");
        hero.Location = "church";
    }
    static void Vault(Hero hero)
    {
        Console.WriteLine("As you enter the room you find riches beyond your imagination. \nYou go to grab a goblet of pure gold, but as soon as you touch it everything goes black");
        hero.Location = "gameover";
        Console.ReadLine();
    }

    static void Basement(Hero hero)
    {
        Console.WriteLine("The minotaur drags your lifeless body down the stairs into the basement, as you are being dragged, everything starts to fade");
        hero.Location = "gameover";
    }

    static void GameOver(Hero hero, List<Items> inventory)
    {
        Console.Clear();
        Console.WriteLine("You wake up in a bed at the inn and the innkeeper asks \n");
        string response = Ask("Do you want to go AGAIN or are you heading HOME?");
        if (response == "home")
        {
            hero.Location = "quit";
        }
        else if (response == "again") // tömmer inventory listan, och återställer spelaren till ursprungsvärden
        {
            inventory.Clear(); 
            hero.Health = 100;
            hero.currentDmg = hero.baseDmg;
            hero.Location = "newgame";
        }
    }
    static void Church(Hero hero)
    {
        Console.WriteLine("You enter the church, and the door slams shut behind you." +
                          "At the altar, you see a towering figure covered in robes." +
                          "The figure turns towards you with a huge axe and starts to charge towards you.");
        bool winner;
        Enemy boss = new Enemy();
        boss.Name = "Minotaur";
        boss.SetStats(boss);
        
        while(true)
        {
            if (hero.Health <= 0)
            {
                hero.Location = "basement";
                break;
            }

            if (boss.Health <= 0)
            {
                Console.WriteLine("The minotaur falls backwards and into a gate you did not see before, \nYou enter the room");
                hero.Location = "vault";
                break;
            }
            EnemyTurn(hero, boss); //Anropar funktionerna som styr vems tur det är under combat
            PlayerTurn(hero, boss);
        }
    }

    static void EnemyTurn(Hero hero, Enemy enemy)
    {
        int roll = RollD6();//Slumpar ett värde 1-6
        
        if (roll <= 2) //Det slumpade värdet styr vad för attack som sker
            {
                enemy.AttackSwipe(enemy);
                string response = Ask("What do you want to do? Jump, parry or dodge? ");
                if (response == "parry")
                {
                    hero.Health -= enemy.swipeDmg / 2;
                    Console.WriteLine($"You attempt to parry the swipe, but you still take {enemy.swipeDmg / 2} damage.");
                    Console.WriteLine(hero.Health);
                }

                if (response == "dodge")
                {
                    hero.Health -= enemy.swipeDmg;
                    Console.WriteLine($"You attempt to dodge backwards, but not far enough! You take {enemy.swipeDmg} damage.");
                    Console.WriteLine(hero.Health);
                }

                if (response == "jump")
                {
                    Console.WriteLine("You manage to jump over the attack and avoid all damage.");
                    Console.WriteLine(hero.Health);
                }

            }
            else if (roll > 2 && roll <= 4) //varför får vi varning här?
            {
                enemy.AttackKick(enemy); 
                string response = Ask("What do you want to do? Jump, parry or dodge? ");
                if (response == "parry")
                {
                    hero.Health -= enemy.kickDmg;
                    Console.WriteLine($"You attempt to parry the kick, but you are unsuccessful. You take {enemy.kickDmg} damage.");
                    Console.WriteLine(hero.Health);
                }

                if (response == "dodge")
                {
                    Console.WriteLine("You dodge to the side of the kick and avoid all damage!");
                    Console.WriteLine(hero.Health);
                }

                if (response == "jump")
                {
                    hero.Health -= enemy.kickDmg / 2;
                    Console.WriteLine($"You try to jump over the kick but it catches your legs mid jump. You land awkwardly and take {enemy.kickDmg / 2} damage. ");
                    Console.WriteLine(hero.Health);
                }
            }
            else if (roll >= 5)
            {
                enemy.AttackStrike(enemy);
                string response = Ask("What do you want to do? Jump, parry or dodge? ");
                if (response == "parry")
                {
                    Console.WriteLine($"You parry the attack and deflect it away from you. You avoid all damage!");
                    Console.WriteLine(hero.Health);
                }

                if (response == "dodge")
                {
                    hero.Health -= enemy.strikeDmg / 2;
                    Console.WriteLine($"The attack graces your arm while trying to dodge to the side. You take {enemy.strikeDmg / 2} damage.");
                    Console.WriteLine(hero.Health);
                }

                if (response == "jump")
                {
                    hero.Health -= enemy.strikeDmg * 2;
                    Console.WriteLine($"You jump straight into the attack and suffer a grievous wound. You take {enemy.strikeDmg * 2} damage. ");
                    Console.WriteLine(hero.Health);
                }
            }
    }
    static void PlayerTurn(Hero hero, Enemy enemy)
    {
        string response = Ask("It's your turn to attack. \nDo you play it safe and SLASH in a big arch \nor try for a more risky and precise STAB? ");
        if (response == "slash")
        {
            enemy.Health -= hero.currentDmg;
            Console.WriteLine($"{enemy.Health} Boss HP");
        }
        else if (response == "stab")
        {
            if (RollD6() >= 4)
            {
                enemy.Health -= hero.currentDmg * 2;
                Console.WriteLine("You hit your mark!");
                Console.WriteLine($"{enemy.Name} has {enemy.Health} HP left!");
            }
            else
            {
                Console.WriteLine("The enemy dodges to the side and you miss.");
                Console.WriteLine($"{enemy.Name} still has {enemy.Health} HP left!");
            }
        }
    }
    static bool SearchItem(List<Items> inventory, string itemName) // Letar om namnet på ett item finns i inventory listan
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

    static void removeItem(List<Items> inventory, string itemName) // Letar först efter itemnamnet i inventory. Om det finns så tas det bort.
    {
        for (int i = 0; i < inventory.Count(); i++)
        {
            if (inventory[i].name == itemName)
            {
                inventory.Remove(inventory[i]);
            }
        }
    }
}
